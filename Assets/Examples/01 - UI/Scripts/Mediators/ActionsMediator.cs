using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityPureMVC;
using UnityPureMVC.Patterns;

namespace lizzard.Examples01
{
    public class ActionsMediator : Mediator
    {
        public ActionsMediator(string mediatorName) : base(mediatorName)
        {
            AddUiEventInterest("DoAction", DoAction);
        }

        private static void DoAction(object body)
        {
            Debug.Log("Action done!");
        }
    }
}