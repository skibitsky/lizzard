using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lizzard.Examples01
{
    public class StartupMacroCommand : UnityPureMVC.StartupMacroCommand
    {
        protected override void InitializeMacroCommand()
        {
            base.InitializeMacroCommand();
            AddSubCommand(() => new StartupProxiesCommand());
        }
    }
}