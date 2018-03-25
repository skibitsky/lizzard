// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace

public static class Notifications
{
    public const string STARTUP = "Startup";
    public const string CREATE_ROOM = "CreateRoom";
    public const string SEND_INPUT = "SendInput";
    public const string APPLY_ANIMATION = "ApplyAnimation";
    public const string RELOAD = "Input.Reload";

    #region EngineProxy
    public const string LOAD_SCENE = "EngineProxy.LoadScene";
    public const string SCENE_LOADED = "EngineProxy.SceneWasLoaded";
    public const string INSTANTIATE = "EngineProxy.INSTANTIATE";
    public const string START_COROUTINE = "EngineProxy.StartCoroutine";
    public const string STOP_COROUTINE = "EngineProxy.StopCoroutine";
    #endregion

    #region NetworkProxy
    public const string AUTHENTICATED = "NetworkProxy.Response.Authenticate";
    public const string SPAWN_LOCAL_PLAYER = "NetworkProxy.Response.SpawnLocalPlayer";
    public const string GAME_CREATED = "NetworkProxy.Response.GameCreated";
    public const string JOINED_RANDOM_ROOM = "NetworkProxy.Response.JoinRandomRoom";

    public const string INITIAL_REGION_STATE = "NetworkProxy.Event.InitialRegionState";
    public const string ADD_PHYSICAL_PLAYER_TO_REGION = "NetworkProxy.Event.AddPhysicalPlayerToRegion";
    public const string SPAWN_OBJECTS = "NetworkProxy.Event.SpawnObjects";
    public const string TOGGLE_OBJ_STATE = "NetworkProxy.Event.ToggleObjectState";
    public const string MOVEMENT = "NetworkProxy.Event.Movement";
    public const string JOINED = "NetworkProxy.Event.Joined";
    public const string DESTROY = "NetworkProxy.Event.Destroy";
    public const string INVENTORY_UPDATE = "NetworkProxy.Event.InventoryUpdateEvent";
    public const string INVENTORY_INIT = "NetworkProxy.Event.InventoryInitEvent";
    public const string PROPERTY_STATUS_UPDATE = "NetworkProxy.Event.PropertyStatusUpdate";
    public const string DEATH_EVENT = "NetworkProxy.Event.Death";
    public const string TELEPORT_EVENT = "NetworkProxy.Event.Teleport";
    public const string RESPAWN_EVENT = "NetworkProxy.Event.Respawn";
    public const string RECEIVE_ANIMATION_EVENT = "NetworkProxy.Event.ReceiveAnimation";

    public const string STATE_JOINED_LOBBY = "NetworkProxy.State.JoinedLobby";
    public const string STATE_JOINED_ROOM = "NetworkProxy.State.JoinedRoom";
    public const string STATE_DISCONNECTED = "NetworkProxy.State.Disconnected";
    public const string STATE_CONNECTED_GAMESERVER = "NetworkProxy.State.ConnectedToGameserver";
    public const string STATE_DISCONNECTING_GAMESERVER = "NetworkProxy.State.DisconnectingFromGameserver";

    public const string SEND_ANIMATION = "NetworkProxy.Operation.SendAnimation";
    #endregion

    #region LoginProxy
    public const string LOGIN = "LoginProxy.Login";
    public const string LOGIN_SUCCESS = "LoginProxy.LoginSuccess";
    public const string LOGIN_FAILED = "LoginProxy.LoginFailed";
    #endregion

    #region InventoryProxy
    public const string INVENTORY_SUBSCRIBE = "InventoryProxy.Subscribe";
    public const string INVENTORY_DELETE = "InventoryProxy.Delete";
    public const string UPDATE_SLOT = "InventoryProxy.UpdateSlot";
    public const string SWITCH_ACTIVE_SLOT = "InventoryProxy.SwitchActiveSlot";
    
    public const string INIT_NLP_HAND = "InventoryProxy.InitNonLocalPlayerHand";
    public const string UPDATE_NLP_HAND = "InventoryProxy.UpdateNonLocalPlayerHand";
    #endregion

    #region UI
    public const string SWITCH_ACTIVE_SLOT_UI = "UI.SwitchActiveSlot";
    public const string UPDATE_HEALTH_UI = "UI.UpdateHealth";
    public const string ENABLE_DEATH_UI = "UI.EnableDeathUi";

    public const string UPDATE_AMMO_UI = "UI.UpdateAmmo";

    #endregion
}

public static class NotificationTypes
{
    public const string OPERATION_RESPONSE = "OperationResponse";
    public const string EVENT_DATA = "EventData";
}

public static class ProxyNames
{
    public const string ENGINE_PROXY = "EngineProxy";
    public const string NETWORK_PROXY = "NetworkProxy";
    public const string LOGIN_PROXY = "LoginProxy";
    public const string NETWORK_OBJECTS_PROXY = "NetworkObjectsProxy";
    public const string NETWORK_REGION_PROXY = "NetworkRegionProxy";
    public const string ROOM_PROXY = "RoomProxy";
    public const string INVENTORY_PROXY = "InventoryProxy";
    public const string ITEMS_PROXY = "ItemsProxy";

}

