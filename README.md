# lizzard
lizzard is an open source framework for Unity Engine. It's mainly based on PureMVC 
pattern and MVVM-style data binding system [Unity Weld](https://github.com/Real-Serious-Games/Unity-Weld). It also contains
[stack-based input system](https://github.com/skibitsky/InputSystem) for desktop and custom for mobile.

It's not easy to begin with PureMVC, but it serve well in the future and make your project as flexible as possible.

## Intall
0. In your Unity project change **Scripting Runtime Version** in Player setting to *.NET 4.x Equivalent*
1. Move [lizzard](https://github.com/skibitsky/lizzard/tree/master/Assets/lizzard) folder to your `/Assets`
2. Create project initialization MacroCommand to set up all Mediators, Proxies and other components of your game:
```csharp
public class MyStartupMacroCommand : MacroCommand
{
    protected override void InitializeMacroCommand()
    {
        base.InitializeMacroCommand();
        AddSubCommand(() => new MyStartupMediatorsCommand());
        AddSubCommand(() => new MyStartupProxiesCommand());
    }
}
```
You can take one of [example](https://github.com/skibitsky/lizzard/tree/master/Assets/Examples) projects as a base.

3. Create Game Launcher script:
```csharp
public class MyGameLauncher : MonoBehaviour
{
    private void Awake()
    {
        // Set up all custom lizzard components
        Facade.GetInstance.RegisterCommand(Notifications.STARTUP, typeof(MyStartupMacroCommand));

        // Launch lizzard
        Facade.GetInstance.Startup();
    }
}
```

## In progress
* Documentation
* Editor tools
* Unity API save wrappers
