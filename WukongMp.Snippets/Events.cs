using System;
using ReadyM.Api.Idents;
using ReadyM.Api.Multiplayer.Client;
using ReadyM.Api.Multiplayer.Generators;
using ReadyM.Api.Multiplayer.Protocol.Enums;
using ReadyM.Api.Multiplayer.RPC;
using ReadyM.Api.Multiplayer.Serialization;
using UnrealEngine.Runtime;
using WukongMp.Sdk.Api;

namespace WukongMp.Snippets;

public partial class  SnippetsRpc(IRpcClient client, IRelaySerializer serializer) : RpcClassBase(client, serializer)
{
    // RPC method to receive string from other Players and show it in local chat with sender PlayerId
    [RpcEvent(RelayMode.AreaOfInterestAll)]
    private void OnExampleEvent(PlayerId __sender, string message)
    {
        WukongApi.Chat.ShowLocalMessage($"Received message from {__sender}: {message}", FLinearColor.Green);
    }

    [RpcEvent(RelayMode.GlobalOthers)]
    public void OnDeath(string victim)
    {
        WukongApi.Local.ShowInfoMessage($"Player {victim} was killed! Rest at Shrine to respawn them.", 5.0f); 
    }
}