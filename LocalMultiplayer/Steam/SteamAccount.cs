using System;

namespace com.github.zehsteam.LocalMultiplayer.Steam;

public struct SteamAccount(string username, ulong steamId) : IEquatable<SteamAccount>
{
    public readonly string Username = username;
    public readonly ulong SteamId = steamId;
    public int ColorId;

    public bool Equals(SteamAccount other) => SteamId == other.SteamId;
    public override bool Equals(object? obj) => obj is SteamAccount other && Equals(other);
    public static bool operator ==(SteamAccount a, SteamAccount b) => a.Equals(b);
    public static bool operator !=(SteamAccount a, SteamAccount b) => !a.Equals(b);
    public override int GetHashCode() => SteamId.GetHashCode();
}
