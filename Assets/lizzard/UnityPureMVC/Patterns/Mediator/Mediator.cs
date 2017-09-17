//
//  UnityPureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@UnityPureMVC.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using System.Collections.Generic;
using UnityPureMVC.Core;
using UnityPureMVC.Interfaces;

namespace UnityPureMVC.Patterns
{
    /// <summary>
    /// A base <c>IMediator</c> implementation. 
    /// </summary>
    /// <seealso cref="T:UnityPureMVC.Core.View" />
    public class Mediator : Notifier, IMediator
    {
        /// <summary>
        /// The name of the <c>Mediator</c>. 
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Typically, a <c>Mediator</c> will be written to serve
        ///         one specific control or group controls and so,
        ///         will not have a need to be dynamically named.
        ///     </para>
        /// </remarks>
        public static string NAME = "Mediator";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mediatorName"></param>
        public Mediator(string mediatorName)
        {
            MediatorName = mediatorName ?? Mediator.NAME;
            MyView = View.GetInstance;
            UiEventsMap = new Dictionary<string, Action<object>>();
        }

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
        ///     <para>
        ///         Typically this will be handled in a switch statement,
        ///         with one 'case' entry per <c>INotification</c>
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
        /// <summary>the mediator name</summary>
        public string MediatorName { get; protected set; }

        protected IView MyView { get; private set; }

        protected IDictionary<string, Action<object>> UiEventsMap;
    }
}
