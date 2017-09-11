//
//  UnityPureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@UnityPureMVC.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using System.Collections.Generic;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace UnityPureMVC.Core
{
    /// <summary>
    /// A Multiton <c>IController</c> implementation.
    /// </summary>
    /// <remarks>
    /// 	<para>In UnityPureMVC, the <c>Controller</c> class follows the 
    /// 	'Command and Controller' strategy, and assumes these 
    /// 	responsibilities:</para>
    /// 	<list type="bullet">
    /// 		<item> Remembering which <c>ICommand</c>s 
    /// 		are intended to handle which <c>INotifications</c>.</item>
    /// 		<item> Registering itself as an <c>IObserver</c> with 
    /// 		the <c>View</c> for each <c>INotification</c> 
    /// 		that it has an <c>ICommand</c> mapping for.</item>
    /// 		<item> Creating a new instance of the proper <c>ICommand</c> 
    /// 		to handle a given <c>INotification</c> when notified by the <c>View</c>.</item>
    /// 		<item>Calling the <c>ICommand</c>'s <c>execute</c> 
    /// 		method, passing in the <c>INotification</c>.</item>
    /// 	</list>
    /// 	<para>
    /// 	    Your application must register <c>ICommands</c> with the 
    /// 	    <c>Controller</c>.
    /// 	</para>
    /// 	<para>
    /// 	    The simplest way is to subclass <c>Facade</c>, 
    /// 	    and use its <c>initializeController</c> method to add your 
    /// 	    registrations.
    /// 	</para>
    /// </remarks>
    /// <seealso cref="UnityPureMVC.Core.View"/>
    /// <seealso cref="UnityPureMVC.Patterns.Observer"/>
    /// <seealso cref="UnityPureMVC.Patterns.Observer"/>
    /// <seealso cref="UnityPureMVC.Patterns"/>
    /// <seealso cref="UnityPureMVC.Patterns"/>
    public class Controller: IController
    {

        public static IController GetInstance
        {
            get
            {
                if (Controller.Instance != null) return Controller.Instance;
                return Controller.Instance ?? (Controller.Instance = new Controller());
            }
        }

        /// <summary>
        /// Constructs and initializes a new controller
        /// </summary>
        /// <remarks>This <c>IController</c> implementation is a Multiton, 
        ///     so you should not call the constructor directly
        ///     Factory method <c>Controller.GetInstance</c>
        /// </remarks>
        public Controller()
        {
            CommandMap = new Dictionary<string, Type>();
            InitializeController();
        }

        /// <summary>
        /// Initialize the Multiton <c>Controller</c> instance
        /// </summary>
        /// <remarks>
        ///     <para>Called automatically by the constructor</para>
        ///     <para>
        ///         Please aware that if you are using a subclass of <c>View</c>
        ///         in your application, you should also subclass <c>Controller</c>
        ///         and override the <c>initializeController</c> method in the following way:
        ///     </para>
        ///     <example>
        ///         <code>
        ///             // ensure that the Controller is talking to my IView implementation
        ///             public override void initializeController()
        ///             {
        ///                 view = MyView.getInstance(multitonKey, () => new MyView(multitonKey));
        ///             }
        ///         </code>
        ///     </example>
        /// </remarks>
        protected virtual void InitializeController()
        {
            MyView = View.GetInstance;
        }

        /// <summary>
        /// If an <c>ICommand</c> has previously been registered 
        /// to handle a the given <c>INotification</c>, then it is executed.
        /// </summary>
        /// <param name="notification">note an <c>INotification</c></param>
        public virtual void ExecuteCommand(INotification notification)
        {
            if (!CommandMap.ContainsKey(notification.Name)) return;

            var instance = Activator.CreateInstance(CommandMap[notification.Name]);
            var command = instance as ICommand;
            if (command != null) command.Execute(notification);
        }

        /// <summary>
        /// Register a particular <c>ICommand</c> class as the handler 
        /// for a particular <c>INotification</c>.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         If a <c>ICommand</c> has already been registered to 
        ///         handle <c>INotification</c>s with this name, it is no longer
        ///         used, the new <c>Func</c> is used instead.
        ///     </para>
        ///     <para>
        ///         The Observer for the new ICommand is only created if this the
        ///         first time an ICommand has been regisered for this Notification name.
        ///     </para>
        /// </remarks>
        /// <param name="notificationName">the name of the <c>INotification</c></param>
        /// <param name="commandType">the <c>ICommand</c> type</param>
        public virtual void RegisterCommand(string notificationName, Type commandType)
        {
            if (!CommandMap.ContainsKey(notificationName))
                MyView.RegisterObserver(notificationName, new Observer(ExecuteCommand, this));
            
            CommandMap[notificationName] = commandType;
        }

        /// <summary>
        /// Remove a previously registered <c>ICommand</c> to <c>INotification</c> mapping.
        /// </summary>
        /// <param name="notificationName">the name of the <c>INotification</c> to remove the <c>ICommand</c> mapping for</param>
        public virtual void RemoveCommand(string notificationName)
        {
            if (!CommandMap.ContainsKey(notificationName)) return;
            MyView.RemoveObserver(notificationName, this);
        }

        /// <summary>
        /// Check if a Command is registered for a given Notification 
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns>whether a Command is currently registered for the given <c>notificationName</c>.</returns>
        public virtual bool HasCommand(string notificationName)
        {
            return CommandMap.ContainsKey(notificationName);
        }

        protected static IController Instance;

        /// <summary>Local reference to View</summary>
        protected IView MyView;

        /// <summary>Mapping of Notification names to Command Class references</summary>
        protected IDictionary<string, Type> CommandMap;
    }
}
