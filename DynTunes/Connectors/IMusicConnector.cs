namespace DynTunes.Connectors;

public interface IMusicConnector
{
    public MediaPlayerState GetState();
    // public bool NeedsPolling { get; }
}