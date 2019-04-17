using lizzard.Commands.MobileInput;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Scripts.Commands
{
    public class RegisterCommandsCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            
            Facade.RegisterCommand(Notifications.DEBUG_LOG, typeof(DebugLogCommand));
            
            #region MobileInput
            
            #if UNITY_IOS || UNITY_ANDROID
            // You can register any of these commands with your own inherted from them
            Facade.RegisterCommand(Notifications.TOUCH_BEGAN, typeof(TouchBeganMacroCommand));
            Facade.RegisterCommand(Notifications.TOUCH_ENDED, typeof(TouchEndedMacroCommand));
            Facade.RegisterCommand(Notifications.TOUCH_CANCELED, typeof(TouchCanceledMacroCommand));
            Facade.RegisterCommand(Notifications.TOUCH_MOVED, typeof(TouchMovedMacroCommand));
            Facade.RegisterCommand(Notifications.TOUCH_STATIONARY, typeof(TouchStationaryMacroCommand));
            #endif
            
            #endregion
        }
    }
}