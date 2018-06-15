using UnityPureMVC.Patterns;

namespace lizzard.Commands.MobileInput
{
    public class TouchBeganMacroCommand : MacroCommand
    {
        protected override void InitializeMacroCommand()
        {
            base.InitializeMacroCommand();
            
            // Add SubCommands to run after touch has begun
            //AddSubCommand(() => new DebugLogCommand());
        }
    }
}