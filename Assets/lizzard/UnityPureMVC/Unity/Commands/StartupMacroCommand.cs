using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace UnityPureMVC.Unity
{
    public class StartupMacroCommand : MacroCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
        }
    }
}
