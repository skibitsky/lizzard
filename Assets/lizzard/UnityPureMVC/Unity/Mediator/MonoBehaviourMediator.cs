using UnityEngine;
using UnityPureMVC.Interfaces;

namespace UnityPureMVC.Unity
{
    /// <summary>
    /// Mediator to use inside of Unity. 
    /// </summary>
    public class MonoBehaviourMediator : MonoBehaviour, IMediator
    {

        private string _mediatorName = "MonoBehaviourMediator";

        /// <summary>The mediator name</summary>
        public string MediatorName { get { return _mediatorName; } protected set { _mediatorName = value; } }

        /// <summary>The view component</summary>
        public object ViewComponent { get; set; }

        /// <summary>
        /// List the <c>INotification</c> names this
        /// <c>Mediator</c> is interested in being notified of.
        /// </summary>
        /// <returns>the list of <c>INotification</c> names</returns>
        public virtual string[] ListNotificationInterests()
        {
            return new string[0];
        }

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

        /// <summary>
        /// Called by the MyView when the Mediator is registered
        /// </summary>
        public virtual void OnRegister()
        {
        }

        /// <summary>
        /// Called by the MyView when the Mediator is removed
        /// </summary>
        public virtual void OnRemove()
        {
        }

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
        }
        
    }
}
