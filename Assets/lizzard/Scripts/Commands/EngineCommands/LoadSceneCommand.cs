using Fanchessy.ValueObjects;
using UnityEngine.SceneManagement;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace Fanchessy.Commands
{
    public class LoadSceneCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            var sceneVo = (LoadSceneVO)notification.Body;
            if (sceneVo.Equals(default(LoadSceneVO))) return;
            UnityEngine.Debug.Log("Load scene....");
            if (sceneVo.Async) SceneManager.LoadSceneAsync(sceneVo.SceneName, sceneVo.Mode);
            else SceneManager.LoadScene(sceneVo.SceneName, sceneVo.Mode);
        }
    }
}