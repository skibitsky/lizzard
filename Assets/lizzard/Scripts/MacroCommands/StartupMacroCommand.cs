using lizzard.Examples01;
using UnityEngine;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Commands
{
    public class StartupMacroCommand : MacroCommand
    {
        protected override void InitializeMacroCommand()
        {
            base.InitializeMacroCommand();
            AddSubCommand(() => new StartupLizzardProxiesCommand());
            AddSubCommand(() => new StartupEngineCommand());
            
            #if UNITY_IOS || UNITY_ANDROID
            AddSubCommand(() => new StartupMobileImput());
            #endif
        }

        // Called after lizzard finished set up
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
 
        }
    }
}