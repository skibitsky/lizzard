using UnityEngine.SceneManagement;

namespace lizzard.ValueObjects
{
    public struct LoadSceneVO
    {
        public LoadSceneVO(string sceneName, LoadSceneMode mode, bool async)
        {
            this.SceneName = sceneName;
            this.Mode = mode;
            this.Async = async;
        }

        public string SceneName;
        public LoadSceneMode Mode;
        public bool Async;     
    }
}