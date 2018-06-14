using lizzard.ValueObjects;
using UnityEngine.SceneManagement;
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
            Facade.RegisterCommand(Notifications.INSTANTIATE, typeof(InstantiateGameObjectCommand));
            
            SceneManager.sceneLoaded += OnSceneWasLoaded;
        }


        /// <summary>
        /// Called afeter new scene was loaded.
        /// Subscribed to SceneManager.sceneLoaded in Execute() above
        /// </summary>
        private void OnSceneWasLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.buildIndex == 0) return;
            var sceneVo = new LoadedSceneVO(scene, mode);
            SendNotification(Notifications.SCENE_LOADED, sceneVo, null);
        }
    }
}