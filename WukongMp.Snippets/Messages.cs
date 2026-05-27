
using ReadyM.Api.Command;
using UnrealEngine.Runtime;
using WukongMp.Sdk.Api;

namespace WukongMp.Snippets;

public static class Messages
{
    public static void AddMessageCommands(IWukongConsoleApi consoleApi)
    {
        consoleApi.AddCommand("local_message", ConsoleCommand.Create(LocalMessage, false));
        consoleApi.AddCommand("banner_message", ConsoleCommand.Create(BannerMessage, false));
        consoleApi.AddCommand("tip_message", ConsoleCommand.Create(TipMessage, false));
        consoleApi.AddCommand("server_message", ConsoleCommand.Create(ServerMessage, false));
    }

    private static void LocalMessage()
    {
        WukongApi.Chat.ShowLocalMessage("This is a local message!", FLinearColor.Orange); // Showing a chat message visible to the local player with text color set to orange
    }

    private static void BannerMessage()
    {
        WukongApi.Local.ShowInfoMessage("This is a banner message!", 5.0f);  // Showing a banner message visible to the local player for 5 seconds
    }

    private static void TipMessage()
    {
        WukongApi.Local.ShowTip("This is a tip message!", true);   // Showing a tip message visible to the local player with auto-hide enabled
    }

    private static void ServerMessage()
    {
        WukongApi.Chat.SendServerMessage("This is a server message!"); // Showing a chat message visible to all players
    }
}