using UnityEngine;
using UnityPureMVC.Patterns;
using lizzard.Commands;
using lizzard.ValueObjects;

namespace lizzard.Examples01
{
    /// <inheritdoc />
    /// <summary>
    /// Spawns object when receives "SpawnAction" UI event from any ModelView
    /// </summary>
    public class SpawnActionMediator : Mediator
    {
        private void Spawn(object body)
        {
            SendNotification(Notifications.INSTANTIATE,
                new InstantiateGameObjectVO(
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