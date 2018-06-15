using System.Collections;
using System.Collections.Generic;
using lizzard.Commands;
using UnityEngine;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Examples01
{
    /// <inheritdoc />
    /// <summary>
    /// Project's initialization MacroCommand
    /// </summary>
    public class MyStartupMacroCommand : MacroCommand
    {
        protected override void InitializeMacroCommand()
        {
            base.InitializeMacroCommand();
            AddSubCommand(() => new StartupMediatorsCommand());
            AddSubCommand(() => new StartupProxiesCommand());
        }
    }
}