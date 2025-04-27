using HarmonyLib;
using Photon.Pun;
using Steamworks;
using Steamworks.Data;
using com.github.zehsteam.LocalMultiplayer.Steam;

namespace com.github.zehsteam.LocalMultiplayer.Patches;

[HarmonyPatch(typeof(SteamManager))]
internal static class SteamManagerPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(SteamManager.Awake))]
    [HarmonyPriority(Priority.First)]
    private static void AwakePatch() => SteamAccountManager.Initialize();
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(SteamManager.OnLobbyCreated))]
    private static void OnLobbyCreatedPatch(ref Result _result, ref Lobby _lobby)
    {
        if (_result != Result.OK) return;
        SteamFriends.SetRichPresence("repo_self_host_lobby_id", _lobby.Id.ToString());
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(nameof(SteamManager.SendSteamAuthTicket))]
    private static void SendSteamAuthTicketPatch()
    {
        var token = SteamHelper.AuthTokenHex;
        if (string.IsNullOrWhiteSpace(token)) return;
        
        PhotonNetwork.AuthValues.UserId = SteamAccountManager.CurrentSteamId.ToString();
        PhotonNetwork.AuthValues.AuthGetParameters = "";
        PhotonNetwork.AuthValues.AddAuthParameter("ticket", token);
    }
}
