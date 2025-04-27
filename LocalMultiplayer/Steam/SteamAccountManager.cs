using Photon.Pun;
using Steamworks;

namespace com.github.zehsteam.LocalMultiplayer.Steam;

internal static class SteamAccountManager
{
    private static SteamAccount _currentUserSteamAccount;
    private static SteamAccount _originalSteamAccount;
    public static bool IsInitialized { get; private set; }
    public static void SetCurrentAccountColor(int id) => _currentUserSteamAccount.ColorId = id;
    public static string CurrentUsername => _currentUserSteamAccount.Username;
    public static ulong CurrentSteamId => _currentUserSteamAccount.SteamId;
    public static int CurrentColorId => _currentUserSteamAccount.ColorId;
    public static ulong OriginalSteamId => _originalSteamAccount.SteamId;
    public static void Initialize()
    {
        if (IsInitialized) return;

        _originalSteamAccount = new SteamAccount(SteamClient.Name, SteamClient.SteamId);
        _currentUserSteamAccount = SteamHelper.SessionId > 0 
            ? new SteamAccount(SteamHelper.GenerateRandomUsername(), SteamHelper.GenerateRandomSteamId()) 
            : _originalSteamAccount;
        
        Plugin.PluginLogger.LogInfo($"SteamAccountManager initialized as: {_currentUserSteamAccount.Username} ({_currentUserSteamAccount.SteamId})");
        PhotonNetwork.NickName = _currentUserSteamAccount.Username;
        IsInitialized = true;
    }
}
