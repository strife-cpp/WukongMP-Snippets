using CSharpModBase.Input;
using ReadyM.Api.DI;
using UnrealEngine.Runtime;
using WukongMp.Sdk;
using WukongMp.Sdk.Api;

namespace WukongMp.Snippets;

public class Mod : ModBase
{
    public override string Name => "WukongMP Snippets"; // TODO: CHANGE ME

    protected override void Initialize(IDependencyContainer services)
    {
        // register and resolve your services:
        services.RegisterSingleton<SnippetsRpc>();
        var rpc = services.Resolve<SnippetsRpc>();

        // register console commands:
        Messages.AddMessageCommands(WukongApi.Console);
        Coordinates.AddCoordinatesCommands(WukongApi.Console);
        Spawn.AddSpawnCommands(WukongApi.Console);
        Spectator.AddSpectatorCommands(WukongApi.Console);

        // register input bindings:
        Keybinds.RegisterKeyBinds();
    }
}