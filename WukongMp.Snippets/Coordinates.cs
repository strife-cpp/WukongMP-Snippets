
using System.Numerics;
using ReadyM.Api.Command;
using UnrealEngine.Runtime;
using WukongMp.Sdk.Api;
using WukongMp.Sdk.Entities;

namespace WukongMp.Snippets;

public static class Coordinates
{
    public static void AddCoordinatesCommands(IWukongConsoleApi consoleApi)
    {
        consoleApi.AddCommand("show_current_coordinates", ConsoleCommand.Create(ShowCoordinates, false));
        consoleApi.AddCommand("show_current_rotation", ConsoleCommand.Create(ShowRotation, false));
        consoleApi.AddCommand("teleport_to_coordinates", ConsoleCommand.Create(TeleportPlayer, false));
        consoleApi.AddCommand("move_player_by_coordinates", ConsoleCommand.Create(MovePlayer, false));
    }

    static private void ShowCoordinates()
    {
        if (WukongApi.Sync.LocalMainCharacter.HasValue)
        {
            Vector3 position = WukongApi.Sync.LocalMainCharacter.Value.Location; // Getting the current location of the player
            WukongApi.Chat.ShowLocalMessage($"Current coordinates: {position}", FLinearColor.NavajoWhite); // Showing a chat message with the current coordinates
        }
    }
        static private void ShowRotation()
    {
        if (WukongApi.Sync.LocalMainCharacter.HasValue)
        {
            Vector3 rotation = WukongApi.Sync.LocalMainCharacter.Value.Rotation; // Getting the current rotation of the player
            WukongApi.Chat.ShowLocalMessage($"Current rotation: {rotation} degrees", FLinearColor.NavajoWhite); // Showing a chat message with the current rotation
        }
    }

    static private void TeleportPlayer(int x = 0, int y = 0, int z = 0)
    {
        if (WukongApi.Sync.LocalMainCharacter.HasValue)
        {   
            string name = WukongApi.Sync.LocalMainCharacter.Value.Nickname; // Getting the player's name
            Vector3 position = new Vector3(x, y, z); // Creating a vector with the specified coordinates
            Vector3 rotation = new Vector3(0, 0, 0); // Getting the current rotation of the player
            WukongApi.Sync.LocalMainCharacter.Value.Teleport(position, rotation); // Teleporting player to the specified location with the specified rotation
            WukongApi.Chat.ShowLocalMessage($"Teleported {name} to coordinates: {position}", FLinearColor.LightPink); // Showing a chat message with the current coordinates
        }
    }
    static private void MovePlayer(int x = 0, int y = 0, int z = 0)
    {
        if (WukongApi.Sync.LocalMainCharacter.HasValue)
        {
            string name = WukongApi.Sync.LocalMainCharacter.Value.Nickname; // Getting the player's name
            Vector3 position = WukongApi.Sync.LocalMainCharacter.Value.Location; // Getting the current location of the player
            Vector3 rotation = WukongApi.Sync.LocalMainCharacter.Value.Rotation; // Getting the current rotation of the player
            Vector3 offset = new Vector3(x, y, z); // Creating a vector with the specified coordinates
            WukongApi.Sync.LocalMainCharacter.Value.Teleport(position + offset, rotation); // Teleporting player to the specified location with the specified rotation
            WukongApi.Chat.ShowLocalMessage($"{name} was moved by: {offset}", FLinearColor.LightPink); // Showing a chat message with the current coordinates
        }
    }
}