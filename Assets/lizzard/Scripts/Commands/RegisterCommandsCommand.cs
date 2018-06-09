using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Commands
{
    // All except Engine commands registration
    public class RegisterCommandsCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
//            Facade.RegisterCommand(Notifications.LOGIN, typeof(LoginCommand));
        }
    }
}