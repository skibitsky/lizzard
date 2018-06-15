using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Examples02.Commands
{
    public class MyStartupMacroCommand : MacroCommand
    {
        protected override void InitializeMacroCommand()
        {
            base.InitializeMacroCommand();
            
            AddSubCommand(() => new StartupProxiesCommand());
            AddSubCommand(() => new RegisterCommandsCommand());
        }

        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            
            SendNotification(ExampleNotifications.SPAWN_PLAYER, null, null);
        }
    }
}