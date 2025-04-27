using com.github.zehsteam.LocalMultiplayer.Steam;
using HarmonyLib;
using Steamworks;

namespace com.github.zehsteam.LocalMultiplayer.Patches;

[HarmonyPatch(typeof(SteamClient))]
internal static class SteamClientPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(SteamClient.Name), MethodType.Getter)]
    private static bool GetName(ref string __result)
    {
        if (!SteamAccountManager.IsInitialized)
            return true;
        
        __result = SteamAccountManager.CurrentUsername;
        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(SteamClient.SteamId), MethodType.Getter)]
    private static bool GetSteamId(ref SteamId __result)
    {
        if (!SteamAccountManager.IsInitialized)
            return true; 
        
        __result = SteamAccountManager.CurrentSteamId;
        return false;
    }
}
