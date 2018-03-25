using Fanchessy.ValueObjects;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace Fanchessy.Commands
{
    public class StartupMacroCommand : MacroCommand
    {
        protected override void InitializeMacroCommand()
        {
            base.InitializeMacroCommand();
            AddSubCommand(() => new RegisterCommandsCommand());
            AddSubCommand(() => new StartupEngineCommand());
            AddSubCommand(() => new StartupProxiesCommand());
            AddSubCommand(() => new StartupMediatorsCommand());
        }

        public override void Execute(INotification notification)
        {
            base.Execute(notification);

            // TODO load initial scene (menu?) here
            SendNotification(Notifications.LOAD_SCENE,
                new LoadSceneVO("Menu", UnityEngine.SceneManagement.LoadSceneMode.Single, true), null);
        }
    }
}