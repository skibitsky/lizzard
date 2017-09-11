//
//  UnityPureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@UnityPureMVC.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

namespace UnityPureMVC.Interfaces
{
    /// <summary>
    /// The interface definition for a UnityPureMVC Command.
    /// </summary>
    /// <seealso cref="INotification"/>
    public interface ICommand: INotifier
    {
        /// <summary>
        /// Execute the <c>ICommand</c>'s logic to handle a given <c>INotification</c>.
        /// </summary>
        /// <param name="notification">an <c>INotification</c> to handle.</param>
        void Execute(INotification notification);
    }
}
