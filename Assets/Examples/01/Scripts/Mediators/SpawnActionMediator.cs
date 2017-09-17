using UnityEngine;
using UnityPureMVC;
using UnityPureMVC.Patterns;

namespace lizzard.Examples01
{
    public class SpawnActionMediator : Mediator
    {

        public void Spawn(object body)
        {
            // TODO: Move spawn to another command and give her class with Object and parent name (pos, rot?)
            var go = Object.Instantiate(((ButtonsProxy)Facade.RetrieveProxy("ButtonsProxy")).GetButton());
            go.transform.SetParent(GameObject.Find("Actions").transform);
        }

        public SpawnActionMediator(string mediatorName) : base(mediatorName)
        {
            AddUiEventInterest("SpawnAction", Spawn);
        }
    }
}