using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace UnityPureMVC
{
    public class StartupMacroCommand : MacroCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
        }
    }
}
