using lizzard.Examples01;
using lizzard.Scripts.Commands;
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
            AddSubCommand(() => new RegisterCommandsCommand());
            
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