
using CSharpModBase.Input;
using UnrealEngine.Runtime;
using WukongMp.Sdk.Api;

namespace WukongMp.Snippets;

public static class Keybinds
{
    static public void RegisterKeyBinds()
    {
        WukongApi.Input.RegisterKeyBind(Key.F6, Spectator.ToggleSpectator); // Registering a keybind for the F6 key that calls the SpectatorKeybind function when pressed
        WukongApi.Input.RegisterKeyBind(Key.F7, () => Spawn.SpawnEnemy("bandit")); // Registering a keybind for the F7 key that calls the SpawnEnemy function when pressed
        WukongApi.Input.RegisterKeyBind(Key.F8, F8KeyPressed); // Registering a keybind for the F8 key that calls the F5KeyPressed function when pressed
    }

    private static void F8KeyPressed()
    {
        WukongApi.Chat.ShowLocalMessage("F8 key pressed!", FLinearColor.Blue); // Showing a chat message visible to the local player with text color set to orange
    }
}