using lizzard.Proxies;
using lizzard.ValueObjects;
using UnityEngine.SceneManagement;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Commands
{
    public class StartupEngineCommand : SimpleCommand
    {

        private LizzardObjectsProxy _lizzardObjectsProxy;
        
        public override void Execute(INotification notification)
        {
            base.Execute(notification);

            _lizzardObjectsProxy = Facade.RetrieveProxy(ProxyNames.LIZZARD_OBJECT_PROXY) as LizzardObjectsProxy;
            if(_lizzardObjectsProxy == null)
                UnityEngine.Debug.LogError("Cannot retrive LizzardObjectProxy");
                
            
            // Engine commands
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
            
            _lizzardObjectsProxy.DeleteAllNullObjects();
            
            SendNotification(Notifications.SCENE_LOADED, sceneVo, null);
        }
    }
}