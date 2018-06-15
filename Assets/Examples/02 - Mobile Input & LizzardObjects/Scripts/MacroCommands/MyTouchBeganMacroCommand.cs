using lizzard.Commands.MobileInput;

namespace lizzard.Examples02.Commands
{
    public class MyTouchBeganMacroCommand : TouchBeganMacroCommand
    {
        protected override void InitializeMacroCommand()
        {
            base.InitializeMacroCommand();
            
            AddSubCommand(() => new PlayerJumpCommand());
        }
    }
}