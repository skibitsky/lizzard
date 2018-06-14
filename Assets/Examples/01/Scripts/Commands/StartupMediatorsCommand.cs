using UnityEngine;
using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Examples01
{
    /// <inheritdoc />
    /// <summary>
    /// Register all preject's mediators
    /// </summary>
    public class StartupMediatorsCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
            Facade.RegisterMediator(new SpawnActionMediator("SpawnAction"));
            Facade.RegisterMediator(new ActionsMediator("Actions"));
        }
    }
}


