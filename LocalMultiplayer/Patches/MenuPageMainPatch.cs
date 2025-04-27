using com.github.zehsteam.LocalMultiplayer.Steam;
using HarmonyLib;
using Steamworks;
using Steamworks.Data;

namespace com.github.zehsteam.LocalMultiplayer.Patches;

[HarmonyPatch(typeof(MenuPageMain))]
internal static class MenuPageMainPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(MenuPageMain.ButtonEventJoinGame))]
    private static bool ButtonEventJoinGamePatch()
    {
        var lobbyIdStr = new Friend(SteamAccountManager.OriginalSteamId).GetRichPresence("repo_self_host_lobby_id");
        if (!ulong.TryParse(lobbyIdStr, out var lobbyId))
            return false;
        
        SteamManager.instance?.OnGameLobbyJoinRequested(new Lobby(lobbyId), SteamAccountManager.CurrentSteamId);
        return false;
    }
}
