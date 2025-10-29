using ResoniteModLoader;

namespace DynTunes;

public partial class DynTunes // Config
{
    private const string KeySpaceDescription = "The space to put the dynamic variables under, e.g. \"User\" for \"User/Music_Title\"";
    private const string KeySpaceDefault = "User";
    [AutoRegisterConfigKey]
    private static readonly ModConfigurationKey<string> KeySpaceInternal = new("DynVarKeySpace", KeySpaceDescription, () => KeySpaceDefault);
    internal static string KeySpace => Config?.GetValue(KeySpaceInternal) ?? "User";
    
    private const string KeyPrefixDescription = "The prefix to prepend to the dynamic variable name, e.g. \"Music_\" for \"User/Music_Title\"";
    private const string KeyPrefixDefault = "Music_";
    [AutoRegisterConfigKey]
    private static readonly ModConfigurationKey<string> KeyPrefixInternal = new("DynVarKeyPrefix", KeyPrefixDescription, () => KeyPrefixDefault);
    internal static string KeyPrefix => Config?.GetValue(KeyPrefixInternal) ?? "Music_";
    
    private const string ArtistDescription = "The name to use for the Artist string";
    private const string ArtistDefault = "Artist";
    [AutoRegisterConfigKey]
    private static readonly ModConfigurationKey<string> ArtistInternal = new("Artist", ArtistDescription, () => ArtistDefault);
    internal static string Artist => Config?.GetValue(ArtistInternal) ?? ArtistDefault;
    
    private const string TitleDescription = "The name to use for the Title string";
    private const string TitleDefault = "Title";
    [AutoRegisterConfigKey]
    private static readonly ModConfigurationKey<string> TitleInternal = new("Title", TitleDescription, () => TitleDefault);
    internal static string Title => Config?.GetValue(TitleInternal) ?? TitleDefault;
    
    private const string PlayingDescription = "The name to use for the IsPlaying boolean";
    private const string PlayingDefault = "IsPlaying";
    [AutoRegisterConfigKey]
    private static readonly ModConfigurationKey<string> PlayingInternal = new("Playing", PlayingDescription, () => PlayingDefault);
    internal static string Playing => Config?.GetValue(PlayingInternal) ?? PlayingDefault;
    
    private const string PositionDescription = "The name to use for the Position float";
    private const string PositionDefault = "Position";
    [AutoRegisterConfigKey]
    private static readonly ModConfigurationKey<string> PositionInternal = new("Position", PositionDescription, () => PositionDefault);
    internal static string Position => Config?.GetValue(PositionInternal) ?? PositionDefault;
}