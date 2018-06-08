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
//            Facade.RegisterMediator(new AmelijaMediator("Amelija"));
//            Facade.RegisterMediator(new HealthMediator("Health"));
//            Facade.RegisterMediator(new DeathMediator("Death"));
//            Facade.RegisterMediator(new PlayerUiMediator("PlayerUI"));
//            Facade.RegisterMediator(new LevelLoadingMediator("LevelLoading"));
//            Facade.RegisterMediator(new AmmoMediator("AmmoMediator"));
        }
    }
}