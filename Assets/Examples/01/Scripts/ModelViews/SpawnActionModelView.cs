using UnityEngine;
using UnityPureMVC.Core;
using UnityWeld.Binding;

namespace lizzard.Examples01
{
    [Binding]
    public class SpawnActionModelView : MonoBehaviour
    {
        [SerializeField] private string _uiEventKey = "SpawnAction";

        [Binding]
        public void PressSpawnButton()
        {
            View.GetInstance.HandleUiEvent(_uiEventKey, null);
        }
    }
}
