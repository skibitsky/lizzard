using UnityEngine;
using UnityPureMVC.Patterns;
using lizzard.Commands;

namespace lizzard.Examples01
{
    public class SpawnActionMediator : Mediator
    {
        public void Spawn(object body)
        {
            SendNotification(NotificationNames.SPAWN_GAMEOBJECT,
                new SpawnableGameObject(
                    ((ButtonsProxy) Facade.RetrieveProxy("ButtonsProxy")).GetButton(),
                    GameObject.Find("Actions").transform,
                    Vector3.zero,
                    Quaternion.identity
                ),
                null
            );
        }

        public SpawnActionMediator(string mediatorName) : base(mediatorName)
        {
            AddUiEventInterest("SpawnAction", Spawn);
        }
    }
}