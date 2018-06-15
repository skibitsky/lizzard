using UnityPureMVC.Patterns;

namespace lizzard.Commands.MobileInput
{
    public class TouchStationaryMacroCommand : MacroCommand
    {
        protected override void InitializeMacroCommand()
        {
            base.InitializeMacroCommand();
            
            // Add SubCommands to run after touch is stationary
            //AddSubCommand(() => new DebugLogCommand());
        }
    }
}