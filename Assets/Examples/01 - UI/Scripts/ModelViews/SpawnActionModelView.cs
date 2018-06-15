using UnityEngine;
using UnityPureMVC.Core;
using UnityWeld.Binding;

namespace lizzard.Examples01
{
    /// <inheritdoc />
    /// <summary>
    /// This MV handels interactions with "Spawn action button" and sends appropriate UI Event
    /// MV shouldn't be aware of Mediators
    /// </summary>
    /// <remarks>MV shouldn't be aware of Mediators</remarks>
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
