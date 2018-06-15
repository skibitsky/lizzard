using UnityPureMVC.Patterns;

namespace lizzard.Commands.MobileInput
{
    public class TouchCanceledMacroCommand : MacroCommand
    {
        protected override void InitializeMacroCommand()
        {
            base.InitializeMacroCommand();
            
            // Add SubCommands to run after touch has been canceled
            //AddSubCommand(() => new DebugLogCommand());
        }
    }
}