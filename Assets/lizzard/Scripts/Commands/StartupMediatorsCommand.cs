using UnityPureMVC.Patterns;
using UnityPureMVC.Interfaces;

namespace lizzard.Commands
{
    public class StartupMediatorsCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
//            Facade.RegisterMediator(new LoginMediator("LoginMediator"));
        }
    }
}