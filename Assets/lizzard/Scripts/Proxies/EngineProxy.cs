using System.Collections;
using lizzard.UnityComponents;
using lizzard.ValueObjects;
using UnityEngine;
using UnityPureMVC.Patterns;
using UnityEngine.SceneManagement;

namespace lizzard.Proxies
{
    public class EngineProxy : Proxy
    {
        private readonly CoroutineRunner _coroutineRunner;

        public EngineProxy(string proxyName, object data = null) : base(proxyName, data)
        {
            // If CoroutineRunner doesn't exist, create a new one
            if (CoroutineRunner.Instance == null)
            {
                new GameObject("CoroutineRunner", typeof(CoroutineRunner), typeof(DontDestroyOnLoad));
            }

            _coroutineRunner = CoroutineRunner.Instance;
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