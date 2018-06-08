using System.Collections;
using lizzard.UnityComponents;
using lizzard.ValueObjects;
using UnityPureMVC.Patterns;
using UnityEngine.SceneManagement;

namespace lizzard.Proxies
{
    public class EngineProxy : Proxy
    {
        private CoroutineRunner _coroutineRunner;

        public EngineProxy(string proxyName, object data = null) : base(proxyName, data)
        {
            SceneManager.sceneLoaded += OnSceneWasLoaded;
            _coroutineRunner = CoroutineRunner.Instance;
        }

        public void OnSceneWasLoaded(Scene scene, LoadSceneMode mode)
        {
            UnityEngine.Debug.Log("SCENE LOADED: " + scene.name);
            if (scene.buildIndex == 0) return;
            var sceneVo = new LoadedSceneVO(scene, mode);
            SendNotification(Notifications.SCENE_LOADED, sceneVo, null);
        }

        #region Coroutine stuff

        public void StartCoroutine(IEnumerator routine)
        {
            if (routine == null) return;
            _coroutineRunner.StartCoroutine(routine);
        }

        public void StopCoroutine(IEnumerator routine)
        {
            if (routine == null) return;
            _coroutineRunner.StopCoroutine(routine);
        }

        public void StopCoroutine(string methodName)
        {
            if (string.IsNullOrEmpty(methodName)) return;
            _coroutineRunner.StopCoroutine(methodName);
        }

        public void StopAllCoroutines()
        {
            _coroutineRunner.StopAllCoroutines();
        }

        #endregion
    }
}