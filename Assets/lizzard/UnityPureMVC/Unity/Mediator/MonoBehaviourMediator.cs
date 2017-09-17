using System;
using System.Collections.Generic;
using UnityEngine;
using UnityPureMVC.Core;
using UnityPureMVC.Interfaces;

namespace UnityPureMVC
{
    /// <summary>
    /// Mediator to use inside of Unity as a component. 
    /// </summary>
    public class MonoBehaviourMediator : MonoBehaviour, IMediator
    {
        [SerializeField]
        private string _mediatorName = "MonoBehaviourMediator";

        /// <inheritdoc />
        /// <summary>The mediator name</summary>
        public string MediatorName { get { return _mediatorName; } protected set { _mediatorName = value; } }

        /// <inheritdoc />
        /// <summary>
        /// List the <c>INotification</c> names this
        /// <c>Mediator</c> is interested in being notified of.
        /// </summary>
        /// <returns>the list of <c>INotification</c> names</returns>
        public virtual string[] ListNotificationInterests()
        {
            return new string[0];
        }

        /// <inheritdoc />
        /// <summary>
        /// Handle <c>INotification</c>s.
        /// </summary>
        /// <remarks>
        ///     <para c="INotification">
        ///         Typically this will be handled in a switch statement,
        ///         with one 'case' entry per
        ///         the <c>Mediator</c> is interested in.
        ///     </para>
        /// </remarks>
        /// <param name="notification"></param>
        public virtual void HandleNotification(INotification notification)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Called by the MyView when the Mediator is registered
        /// </summary>
        public virtual void OnRegister()
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Called by the MyView when the Mediator is removed
        /// </summary>
        public virtual void OnRemove()
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Called by the View. Handles UiEvent notification
        /// </summary>
        public virtual void HandleUiEvent(string key, object data)
        {
            Action<object> action;
            if (UiEventsMap.TryGetValue(key, out action))
                action.Invoke(data);
        }

        public void AddUiEventInterest(string key, Action<object> action)
        {
            if (UiEventsMap.ContainsKey(key))
                UiEventsMap[key] += action;
            else
            {
                UiEventsMap.Add(key, action);
                MyView.AddUiEventListener(key, this);
            }
        }

        public void RemoveUiEventInterest(string key)
        {
            if (UiEventsMap.ContainsKey(key))
                UiEventsMap.Remove(key);
            MyView.RemoveUiEventListener(key);
        }

        public void RemoveUiEventInterest(string key, Action<object> action)
        {
            if (!UiEventsMap.ContainsKey(key)) return;
            UiEventsMap[key] -= action;
            if (UiEventsMap[key].GetInvocationList().Length == 0)
                RemoveUiEventInterest(key);
        }

        /// <inheritdoc />
        /// <summary>
        /// Create and send an <c>INotification</c>.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Keeps us from having to construct new INotification 
        ///         instances in our implementation code.
        ///     </para>
        /// </remarks>
        /// <param name="notificationName">the name of the notiification to send</param>
        /// <param name="body">the body of the notification (optional)</param>
        /// <param name="type">the type of the notification (optional)</param>
        public virtual void SendNotification(string notificationName, object body, string type)
        {
            Facade.SendNotification(notificationName, body, type);
        }

        /// <summary> Return the Facade instance</summary>
        protected IFacade Facade
        {
            get { return Patterns.Facade.GetInstance; }
        }

        private void OnDisable()
        {
            Facade.RemoveMediator(this.MediatorName);
        }

        private void OnEnable()
        {
            Facade.RegisterMediator(this);
            MyView = View.GetInstance;
            UiEventsMap = new Dictionary<string, Action<object>>();
        }

        protected IView MyView { get; private set; }

        protected IDictionary<string, Action<object>> UiEventsMap;
    }
}
