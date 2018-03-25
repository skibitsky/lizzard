using UnityEngine.SceneManagement;

namespace Fanchessy.ValueObjects
{
    public struct LoadedSceneVO
    {
        public LoadedSceneVO(Scene scene, LoadSceneMode loadSceneMode)
        {
            this.Scene = scene;
            this.LoadSceneMode = loadSceneMode;
        }

        public Scene Scene;
        public LoadSceneMode LoadSceneMode;
    }
}