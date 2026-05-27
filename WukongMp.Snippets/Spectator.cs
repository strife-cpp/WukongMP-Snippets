
using ReadyM.Api.Command;
using ReadyM.Wukong.Common.ECS.Values;
using UnrealEngine.Runtime;
using WukongMp.Sdk.Api;

namespace WukongMp.Snippets;

public static class Spectator
{
    public static void AddSpectatorCommands(IWukongConsoleApi consoleApi)
    {
        consoleApi.AddCommand("spectator", ConsoleCommand.Create(ToggleSpectator, false));
    }
    static public void ToggleSpectator() //Declaring function to toggle spectator mode on and off
    {
        if (WukongApi.Sync.LocalMainCharacter is not { } player) return; // Checking if the local player has a main character

        if (!player.IsSpectator) // If the player is not currently in spectator mode
        {
            WukongApi.Sync.EnableSpectatorMode(player, SpectatorReason.Observer); // If player is not in spectator mode, enable it with reason "Observer"
            WukongApi.Chat.ShowLocalMessage("Spectator mode enabled!", FLinearColor.LightGray);
        }
        else
        {
            WukongApi.Sync.DisableSpectatorMode(player); // If player is already in spectator mode, disable it and return to normal gameplay
            WukongApi.Chat.ShowLocalMessage("Spectator mode disabled!", FLinearColor.LightGray);
        }
    }

}


