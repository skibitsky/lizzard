//
//  UnityPureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@UnityPureMVC.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System.Collections.Generic;
using lizzard;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace UnityPureMVC.Core
{
    /// <summary>
    /// A <c>IView</c> implementation.
    /// </summary>
    /// <remarks>
    ///     <para>In UnityPureMVC, the <c>View</c> class assumes these responsibilities:</para>
    ///     <list type="bullet">
    ///         <item>Maintain a cache of <c>IMediator</c> instances</item>
    ///         <item>Provide methods for registering, retrieving, and removing <c>IMediators</c></item>
    ///         <item>Managing the observer lists for each <c>INotification</c> in the application</item>
    ///         <item>Providing a method for attaching <c>IObservers</c> to an <c>INotification</c>'s observer list</item>
    ///         <item>Providing a method for broadcasting an <c>INotification</c></item>
    ///         <item>Notifying the <c>IObservers</c> of a given <c>INotification</c> when it broadcast</item>
    ///     </list>
    /// </remarks>
    /// <seealso cref="UnityPureMVC.Patterns.Mediator"/>
    /// <seealso cref="UnityPureMVC.Patterns"/>>
    public class View: IView
    {
        public static IView GetInstance
        {
            get
            {
                if (View.Instance != null) return View.Instance;
                return View.Instance ?? (View.Instance = (IView) new View());
            }
        }

        /// <summary>
        /// Constructs and initializes a new view
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         This <c>IView</c> implementation is a Multiton, 
        ///         so you should not call the constructor directly
        ///         Factory method <c>View.GetInstance</c>
        ///     </para>
        /// </remarks>
        public View()
        {
            MediatorMap = new Dictionary<string, IMediator>();
            ObserverMap = new Dictionary<string, IList<IObserver>>();
            UiEventsMap = new Dictionary<string, IList<IMediator>>();
            ModelViewMap = new Dictionary<string, MonoBehaviourModelView>();
            InitializeView();
        }

        /// <summary>
        /// Initialize the View instance.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Called automatically by the constructor, this
        ///         is your opportunity to initialize the
        ///         instance in your subclass without overriding the
        ///         constructor.
        ///     </para>
        /// </remarks>
        protected virtual void InitializeView()
        {
        }

        /// <inheritdoc />
        /// <summary>
        ///     Register an <c>IObserver</c> to be notified
        ///     of <c>INotifications</c> with a given name.
        /// </summary>
        /// <param name="notificationName">the name of the <c>INotifications</c> to notify this <c>IObserver</c> of</param>
        /// <param name="observer">the <c>IObserver</c> to register</param>
        public virtual void RegisterObserver(string notificationName, IObserver observer)
        {
            if (!ObserverMap.ContainsKey(notificationName))
                ObserverMap.Add(notificationName, new List<IObserver>());
            ObserverMap[notificationName].Add(observer);
        }

        /// <inheritdoc />
        /// <summary>
        /// Notify the <c>IObservers</c> for a particular <c>INotification</c>.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         All previously attached <c>IObservers</c> for this <c>INotification</c>'s
        ///         list are notified and are passed a reference to the <c>INotification</c> in
        ///         the order in which they were registered.
        ///     </para>
        /// </remarks>
        /// <param name="notification"></param>
        public virtual void NotifyObservers(INotification notification)
        {
            // Get a reference to the observers list for this notification name
            IList<IObserver> observersRef;
            
            if (!ObserverMap.TryGetValue(notification.Name, out observersRef)) return;
            // Copy observers from reference array to working array, 
            // since the reference array may change during the notification loop
            var observers = new List<IObserver>(observersRef);
            foreach (var observer in observers)
            {
                observer.NotifyObserver(notification);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Remove the observer for a given notifyContext from an observer list for a given Notification name.
        /// </summary>
        /// <param name="notificationName">which observer list to remove from </param>
        /// <param name="notifyContext">remove the observer with this object as its notifyContext</param>
        public virtual void RemoveObserver(string notificationName, object notifyContext)
        {
            IList<IObserver> observers;
            if (!ObserverMap.TryGetValue(notificationName, out observers)) return;
            for (var i = 0; i < observers.Count; i++)
            {
                if (!observers[i].CompareNotifyContext(notifyContext)) continue;
                observers.RemoveAt(i);
                break;
            }

            // Also, when a Notification's Observer list length falls to
            // zero, delete the notification key from the observer map
            if (observers.Count == 0 && ObserverMap.ContainsKey(notificationName))
                ObserverMap.Remove(notificationName);
        }

        /// <inheritdoc />
        /// <summary>
        /// Register an <c>IMediator</c> instance with the <c>View</c>.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Registers the <c>IMediator</c> so that it can be retrieved by name,
        ///         and further interrogates the <c>IMediator</c> for its 
        ///         <c>INotification</c> interests.
        ///     </para>
        ///     <para>
        ///         If the <c>IMediator</c> returns any <c>INotification</c>
        ///         names to be notified about, an <c>Observer</c> is created encapsulating 
        ///         the <c>IMediator</c> instance's <c>handleNotification</c> method 
        ///         and registering it as an <c>Observer</c> for all <c>INotifications</c> the
        ///         <c>IMediator</c> is interested in.
        ///     </para>
        /// </remarks>
        /// <param name="mediator">the name to associate with this <c>IMediator</c> instance</param>
        public virtual void RegisterMediator(IMediator mediator)
        {
            if (MediatorMap.ContainsKey(mediator.MediatorName)) return;

            MediatorMap[mediator.MediatorName] = mediator;
            var interests = mediator.ListNotificationInterests();
            if (interests.Length > 0)
            {
                var observer = new Observer(mediator.HandleNotification, mediator);
                foreach (var i in interests)
                {
                    RegisterObserver(i, observer);
                }
            }

            // alert the mediator that it has been registered
            mediator.OnRegister();
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve an <c>IMediator</c> from the <c>View</c>.
        /// </summary>
        /// <param name="mediatorName">the name of the <c>IMediator</c> instance to retrieve.</param>
        /// <returns>the <c>IMediator</c> instance previously registered with the given <c>mediatorName</c>.</returns>
        public virtual IMediator RetrieveMediator(string mediatorName)
        {
            IMediator mediator;
            MediatorMap.TryGetValue(mediatorName, out mediator);
            return mediator;
        }

        /// <inheritdoc />
        /// <summary>
        /// Remove an <c>IMediator</c> from the <c>View</c>.
        /// </summary>
        /// <param name="mediatorName">name of the <c>IMediator</c> instance to be removed.</param>
        /// <returns>the <c>IMediator</c> that was removed from the <c>View</c></returns>
        public virtual IMediator RemoveMediator(string mediatorName)
        {
            if (!MediatorMap.ContainsKey(mediatorName)) return null;
            var mediator = MediatorMap[mediatorName];
            var interests = mediator.ListNotificationInterests();
            foreach (var i in interests)
            {
                RemoveObserver(i, mediator);
            }
            mediator.OnRemove();
            return mediator;
        }

        /// <inheritdoc />
        /// <summary>
        /// Check if a Mediator is registered or not
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns>whether a Mediator is registered with the given <c>mediatorName</c>.</returns>
        public virtual bool HasMediator(string mediatorName)
        {
            return MediatorMap.ContainsKey(mediatorName);
        }

        /// <inheritdoc />
        /// <summary>
        /// Handles UI event from UI/ViewModel. Looks for IMediators interested in the key
        /// </summary>
        /// <param name="key">Event key</param>
        /// <param name="body">Optional body</param>
        /// <returns>False if no one is interested</returns>
        public virtual bool HandleUiEvent(string key, object body)
        {
            IList<IMediator> mediators;
            if (UiEventsMap.TryGetValue(key, out mediators))
                foreach (var m in mediators)
                    m.HandleUiEvent(key, body);
            else return false;
            return true;
        }

        public virtual void AddUiEventListener(string key, IMediator mediator)
        {
            IList<IMediator> mediators;
            if (UiEventsMap.TryGetValue(key, out mediators))
            {
                if (!mediators.Contains(mediator))
                    UiEventsMap[key].Add(mediator);
            }
            else UiEventsMap.Add(key, new List<IMediator> {mediator});
        }

        public virtual void RemoveUiEventListener(string key)
        {
            if (UiEventsMap.ContainsKey(key))
                UiEventsMap.Remove(key);
        }

        public virtual void RegisterModelView(string key, MonoBehaviourModelView monoBehaviourModelView)
        {
            if (!ModelViewMap.ContainsKey(key))
                ModelViewMap.Add(key, monoBehaviourModelView);
            else
                UnityEngine.Debug.LogErrorFormat("Model view <i>{0}</i> already exists", key);
        }

        public virtual MonoBehaviourModelView RetrieveViewModel(string key)
        {
            MonoBehaviourModelView result;
            return ModelViewMap.TryGetValue(key, out result) ? result : null;
        }

        public virtual void RemoveModelView(string key)
        {
            if (key == null) return;
            if (ModelViewMap.ContainsKey(key)) ModelViewMap.Remove(key);
        }

        /// <summary> Singleton /// </summary>
        protected static IView Instance;

        /// <summary>Mapping of Mediator names to Mediator instances</summary>
        protected IDictionary<string, IMediator> MediatorMap;

        /// <summary>Mapping of Notification names to Observer lists</summary>
        protected IDictionary<string, IList<IObserver>> ObserverMap;

        /// <summary>
        /// Mapping of UiEvents by key to Mediators list
        /// </summary>
        protected IDictionary<string, IList<IMediator>> UiEventsMap;

        protected IDictionary<string, MonoBehaviourModelView> ModelViewMap;
    }
}
