using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Scripts.Commands
{
    public class DebugLogCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);

            UnityEngine.Debug.Log("Debug: " +notification.Body);
        }
    }
}