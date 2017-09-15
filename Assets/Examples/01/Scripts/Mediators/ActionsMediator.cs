using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityPureMVC;
using UnityWeld.Binding;

namespace lizzard.Examples01
{
    [Binding]
    public class ActionsMediator : MonoBehaviourMediator
    {
        [Binding]
        public void Tst()
        {
            Debug.Log("Test 2");
        }
        
    }
}