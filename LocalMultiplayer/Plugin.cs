using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace com.github.zehsteam.LocalMultiplayer;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
internal sealed class Plugin : BaseUnityPlugin
{
    private readonly Harmony _harmony = new(MyPluginInfo.PLUGIN_GUID);
    internal static ManualLogSource PluginLogger { get; } =
        BepInEx.Logging.Logger.CreateLogSource(MyPluginInfo.PLUGIN_GUID);
    private void Awake()
    {
        _harmony.PatchAll();
        
        PluginLogger.LogInfo($"{MyPluginInfo.PLUGIN_NAME} has loaded!");
    }
}
