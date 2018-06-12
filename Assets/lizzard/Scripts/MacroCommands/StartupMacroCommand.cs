using lizzard.ValueObjects;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Commands
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
            
            #if UNITY_IOS || UNITY_ANDROID
            AddSubCommand(() => new StartupMobileImput());
            #endif
        }

        // You can load initial scene (menu?) here
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
 
//            SendNotification(Notifications.LOAD_SCENE,
//                new LoadSceneVO("Menu", UnityEngine.SceneManagement.LoadSceneMode.Single, true), null);
        }
    }
}