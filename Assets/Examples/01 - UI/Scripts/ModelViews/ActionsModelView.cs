using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityPureMVC.Core;
using UnityWeld.Binding;

namespace lizzard.Examples01
{
    /// <inheritdoc />
    /// <summary>
    /// This MV handels interactions with "DO ACTION" and sends appropriate UI Event
    /// MV shouldn't be aware of Mediators
    /// </summary>
    /// <remarks>MV shouldn't be aware of Mediators</remarks>
    [Binding]
    public class ActionsModelView : MonoBehaviour
    {
        [SerializeField] private string _uiEventKey = "DoAction";

        [Binding]
        public void PressDoActionButton()
        {
            Debug.Log("Do action!");
            View.GetInstance.HandleUiEvent(_uiEventKey, null);
        }
    }
}