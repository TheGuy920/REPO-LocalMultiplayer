using HarmonyLib;

namespace com.github.zehsteam.LocalMultiplayer.Patches;

[HarmonyPatch(typeof(InputManager))]
internal static class InputManagerPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(InputManager.SaveDefaultKeyBindings))]
    private static bool SaveDefaultKeyBindingsPatch() => false;

    [HarmonyPrefix]
    [HarmonyPatch(nameof(InputManager.SaveCurrentKeyBindings))]
    private static bool SaveCurrentKeyBindingsPatch() => false;
}
