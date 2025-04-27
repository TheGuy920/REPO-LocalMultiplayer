using com.github.zehsteam.LocalMultiplayer.Steam;
using HarmonyLib;

namespace com.github.zehsteam.LocalMultiplayer.Patches;

[HarmonyPatch(typeof(DataDirector))]
internal static class DataDirectorPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(DataDirector.SaveSettings))]
    private static bool SaveSettingsPatch() => false;

    [HarmonyPrefix]
    [HarmonyPatch(nameof(DataDirector.ColorSetBody))]
    private static bool ColorSetBodyPatch(int colorID)
    {
        SteamAccountManager.SetCurrentAccountColor(colorID);
        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(DataDirector.ColorGetBody))]
    private static bool ColorGetBodyPatch(ref int __result)
    {
        __result = SteamAccountManager.CurrentColorId;
        return false;
    }
}
