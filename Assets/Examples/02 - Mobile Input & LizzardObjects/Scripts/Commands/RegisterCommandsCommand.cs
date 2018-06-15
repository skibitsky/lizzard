using lizzard.Examples02.Commands;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Examples02
{
    public class RegisterCommandsCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);

            Facade.RegisterCommand(ExampleNotifications.SPAWN_PLAYER, typeof(SpawnPlayerCommand));
            Facade.RegisterCommand(ExampleNotifications.JUMP, typeof(PlayerJumpCommand));
            
            #if UNITY_IOS || UNITY_ANDROID
            Facade.RegisterCommand(Notifications.TOUCH_BEGAN, typeof(MyTouchBeganMacroCommand));
            #endif
        }
    }
}