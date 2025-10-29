using DynTunes.Connectors;
using FrooxEngine;
using HarmonyLib;
using ResoniteModLoader;

namespace DynTunes;

public partial class DynTunes : ResoniteMod
{
    public override string Name => nameof(DynTunes);
    public override string Author => "jvyden";
    public override string Version => typeof(DynTunes).Assembly.GetName().Version?.ToString() ?? "0.0.0";
    public override string Link => "https://github.com/jvyden/" + nameof(DynTunes);
    
    public static ModConfiguration? Config { get; private set; }

    public static IMusicConnector Connector;

    public override void OnEngineInit()
    {
        Harmony harmony = new("xyz.jvyden." + nameof(DynTunes));
        Config = GetConfiguration();
        Config?.Save(true);
        harmony.PatchAll();

        Engine.Current.OnReady += () =>
        {
            Connector = new MPRISMusicConnector();
        };
    }
}