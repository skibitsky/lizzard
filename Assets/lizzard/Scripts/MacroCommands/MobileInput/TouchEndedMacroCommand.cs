using UnityPureMVC.Patterns;

namespace lizzard.Commands.MobileInput
{
    public class TouchEndedMacroCommand : MacroCommand
    {
        protected override void InitializeMacroCommand()
        {
            base.InitializeMacroCommand();
            
            // Add SubCommands to run after touch has Ended
            //AddSubCommand(() => new DebugLogCommand());
        }
    }
}