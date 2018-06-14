// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace

public static class Notifications
{
    public const string STARTUP_LIZZARD = "StartupLizzard";
    public const string STARTUP = "Startup";

    #region EngineProxy
    public const string LOAD_SCENE = "EngineProxy.LoadScene";
    public const string SCENE_LOADED = "EngineProxy.SceneWasLoaded";
    public const string INSTANTIATE = "EngineProxy.Instantiate";
    public const string START_COROUTINE = "EngineProxy.StartCoroutine";
    public const string STOP_COROUTINE = "EngineProxy.StopCoroutine";
    
    
    #if UNITY_IOS || UNITY_ANDROID
    public const string TOUCH_BEGAN = "EngineProxy.TouchBegan";
    public const string TOUCH_ENDED = "EngineProxy.TouchEnded";
    public const string TOUCH_CANCELED = "EngineProxy.ToucCanceled";
    public const string TOUCH_MOVED = "EngineProxy.ToucMoved";
    public const string TOUCH_STATIONARY = "EngineProxy.Stationary";
    #endif
    
    #endregion

}

public static class ProxyNames
{
    public const string ENGINE_PROXY = "EngineProxy";
    public const string LIZZARD_OBJECT_PROXY = "LizzardObjectProxy";
}

