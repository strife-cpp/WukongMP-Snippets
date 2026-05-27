
using HarmonyLib;
using UnrealEngine.Engine;
using UnrealEngine.Runtime;
using WukongMp.Api;
using WukongMp.Api.Configuration;

namespace WukongMp.Snippets;

// use Harmony to patch a game method, for example:
[HarmonyPatch(typeof(UGameplayStatics), nameof(UGameplayStatics.OpenLevel))]
[HarmonyPatchCategory(PatchCategory.Global)]
public static class PatchGame
{
    public static void Postfix(FName LevelName)
    {
        Logging.LogDebug("Entering level: {LevelName}", LevelName.ToString());
    }
}