using HarmonyLib;
using Photon.Pun;
using Steamworks;

namespace com.github.zehsteam.LocalMultiplayer.Patches;

[HarmonyPatch(typeof(PlayerAvatar))]
internal static class PlayerAvatarPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(PlayerAvatar.AddToStatsManager))]
    private static void AddToStatsManagerPatch() => PhotonNetwork.NickName = SteamClient.Name;
}
