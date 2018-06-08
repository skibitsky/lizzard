using UnityPureMVC.Interfaces;
using UnityPureMVC.Patterns;

namespace lizzard.Commands
{
    // All except Engine commands registration
    public class RegisterCommandsCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
//            Facade.RegisterCommand(Notifications.LOGIN, typeof(LoginCommand));
//            Facade.RegisterCommand(Notifications.AUTHENTICATED, typeof(ResponseAuthenticateCommand));
//            Facade.RegisterCommand(Notifications.STATE_JOINED_LOBBY, typeof(JoinDefaultRoomCommand));
//            Facade.RegisterCommand(Notifications.STATE_JOINED_ROOM, typeof(StateJoinedCommand));
//            Facade.RegisterCommand(Notifications.JOINED_RANDOM_ROOM, typeof(ResponseJoinRandomRoomCommand));
//            Facade.RegisterCommand(Notifications.CREATE_ROOM, typeof(CreateRoomCommand));
//            Facade.RegisterCommand(Notifications.SCENE_LOADED, typeof(GetInitialStateCommand));
//            Facade.RegisterCommand(Notifications.INITIAL_REGION_STATE, typeof(EvInitialRegionStateCommand));
//            Facade.RegisterCommand(Notifications.SPAWN_LOCAL_PLAYER, typeof(ResponseSpawnLocalPlayerMacroCommand));
//            Facade.RegisterCommand(Notifications.SPAWN_OBJECTS, typeof(SpawnObjectsCommand));
//            Facade.RegisterCommand(Notifications.ADD_PHYSICAL_PLAYER_TO_REGION,
//                typeof(EvAddPhysicalPlayerToRegionCommand));
//            Facade.RegisterCommand(Notifications.TOGGLE_OBJ_STATE, typeof(EvToggleObjectStateCommand));
//            Facade.RegisterCommand(Notifications.GAME_CREATED, typeof(ResponseGameCreatedCommand));
//            Facade.RegisterCommand(Notifications.MOVEMENT, typeof(EvMovementCommand));
//            Facade.RegisterCommand(Notifications.DESTROY, typeof(EvDestroyCommand));
//            Facade.RegisterCommand(Notifications.INVENTORY_INIT, typeof(EvInitInventoryCommand));
//            Facade.RegisterCommand(Notifications.INVENTORY_SUBSCRIBE, typeof(ToggleInventoryUpdateSubscriptionCommand));
//            Facade.RegisterCommand(Notifications.INVENTORY_UPDATE, typeof(EvUpdateInventoryCommand));
//            Facade.RegisterCommand(Notifications.INVENTORY_DELETE, typeof(DeleteInventoryCommand));
//            Facade.RegisterCommand(Notifications.STATE_DISCONNECTED, typeof(StateDisconnectedCommand));
//            Facade.RegisterCommand(Notifications.SEND_INPUT, typeof(SendInputCommand));
//            Facade.RegisterCommand(Notifications.UPDATE_SLOT, typeof(UpdateSlotCommand));
//            Facade.RegisterCommand(Notifications.PROPERTY_STATUS_UPDATE, typeof(EvPropertyUpdateCommand));
//            Facade.RegisterCommand(Notifications.SWITCH_ACTIVE_SLOT, typeof(SwitchActiveSlotCommand));
//            Facade.RegisterCommand(Notifications.INIT_NLP_HAND, typeof(InitNonLocalPlayerHandCommand));
//            Facade.RegisterCommand(Notifications.UPDATE_NLP_HAND, typeof(EvUpdateNlpHandCommand));
//            Facade.RegisterCommand(Notifications.DEATH_EVENT, typeof(EvDeathCommand));
//            Facade.RegisterCommand(Notifications.TELEPORT_EVENT, typeof(EvTeleportCommand));
//            Facade.RegisterCommand(Notifications.RESPAWN_EVENT, typeof(EvRespawnCommand));
//            Facade.RegisterCommand(Notifications.RECEIVE_ANIMATION_EVENT, typeof(EvReceiveAnimationCommand));
//            Facade.RegisterCommand(Notifications.APPLY_ANIMATION, typeof(ApplyAnimationCommand));
//            Facade.RegisterCommand(Notifications.SEND_ANIMATION, typeof(OpSendAnimationCommand));
//            Facade.RegisterCommand(Notifications.RELOAD, typeof(ReloadCommand));
        }
    }
}