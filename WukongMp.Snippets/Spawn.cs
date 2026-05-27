
using System.Linq;
using ReadyM.Api.Command;
using WukongMp.Api.Configuration;
using WukongMp.Sdk.Api;
using WukongMp.Sdk.Entities;

namespace WukongMp.Snippets;

public static class Spawn
{
    
    public static void AddSpawnCommands(IWukongConsoleApi consoleApi)
    {
        var enemy_list = TamerKinds.GetAllValidTamerKinds().Select(x => x.Name); // Getting a list of all valid enemy types that can be spawned
        consoleApi.AddCommand("spawn_enemy", ConsoleCommand.Create(SpawnEnemy, false), enemy_list);
    }

    public static void SpawnEnemy(string enemy = "wolfscout") //Declaring funcion with input parameter "enemy" with fault value "Choose enemy to spawn"
    {
        if (WukongApi.Sync.LocalMainCharacter.HasValue) // Checking if the local player has a main character (is alive and not in spectator mode) - if null it will fail to compile
        {
            var name = WukongApi.Sync.LocalMainCharacter.Value.Nickname; // Getting the player's name
            WukongApi.Sync.SpawnEnemy(new TamerKind(enemy), WukongApi.Sync.LocalMainCharacter.Value.Location); // Spawning chosen enemy at the specified position
            WukongApi.Chat.SendServerMessage($"{name} has spawned: {enemy}!"); // Showing a chat message showing what enemy is spawning
        }
    }
}