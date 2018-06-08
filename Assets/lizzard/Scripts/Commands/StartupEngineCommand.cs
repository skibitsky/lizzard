using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Commands
{
    public class StartupEngineCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            Facade.RegisterCommand(Notifications.LOAD_SCENE, typeof(LoadSceneCommand));
            Facade.RegisterCommand(Notifications.START_COROUTINE, typeof(StartCoroutineCommand));
            Facade.RegisterCommand(Notifications.STOP_COROUTINE, typeof(StopCoroutineCommand));
        }
    }
}