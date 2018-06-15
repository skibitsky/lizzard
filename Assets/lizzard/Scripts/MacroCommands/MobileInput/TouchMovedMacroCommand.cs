using UnityPureMVC.Patterns;

namespace lizzard.Commands.MobileInput
{
    public class TouchMovedMacroCommand : MacroCommand
    {
        protected override void InitializeMacroCommand()
        {
            base.InitializeMacroCommand();
            // Add SubCommands to run after touch has been moved
            //AddSubCommand(() => new DebugLogCommand());
        }
    }
}