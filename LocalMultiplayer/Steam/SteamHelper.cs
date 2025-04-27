using System;
using System.IO;

namespace com.github.zehsteam.LocalMultiplayer.Steam;

internal static class SteamHelper
{
    public static int SessionId { get; } = int.Parse(Environment.GetEnvironmentVariable("REPO_SESSION_ID") ?? "0");
    public static string AuthTokenHex => SessionId > 0 ? File.ReadAllText("token.txt") : string.Empty;
    public static string GenerateRandomUsername() => $"Player {SessionId}";
    public static ulong GenerateRandomSteamId()
    {
        // SteamID64 base value for individual users
        const ulong steamIdBase = 76561197960265728;
        
        // Generate a random 32-bit unsigned integer
        var random = new Random();
        var randomPart = (uint)random.Next(0, int.MaxValue);
        randomPart += (uint)random.Next(0, int.MaxValue);

        return steamIdBase + randomPart;
    }
}
