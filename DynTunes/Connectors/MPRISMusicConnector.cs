using DynTunes.Integration;
using Tmds.DBus.Protocol;

namespace DynTunes.Connectors;

public class MPRISMusicConnector : IMusicConnector
{
    public MPRISMusicConnector()
    {
        Task.Factory.StartNew(ConnectAndRunAsync, TaskCreationOptions.LongRunning);
    }

    private async Task ConnectAndRunAsync()
    {
        try
        {
            using Connection connection = new(Address.Session!);
            await connection.ConnectAsync();

            MPRISService service = new(connection, "org.mpris.MediaPlayer2.spotify");
            Player player = service.CreatePlayer("/org/mpris/MediaPlayer2");

            while (true)
            {
                long position = await player.GetPositionAsync();
                _state.PositionSeconds = (float)(position / (decimal)TimeSpan.MicrosecondsPerSecond);

                string playbackStatus = await player.GetPlaybackStatusAsync();
                _state.IsPlaying = playbackStatus == "Playing";


                Dictionary<string, VariantValue>? metadata = await player.GetMetadataAsync();
                foreach ((string key, VariantValue value) in metadata)
                {
                    switch (key)
                    {
                        case "mpris:artUrl":
                            _state.AlbumArtUrl = value.GetString();
                            break;
                        case "mpris:length":
                            _state.LengthSeconds = (float)(value.GetUInt64() / (decimal)TimeSpan.MicrosecondsPerSecond);
                            break;
                        case "xesam:album":
                            _state.Album = value.GetString();
                            break;
                        case "xesam:artist":
                            _state.Artist = string.Join(", ", value.GetArray<string>());
                            break;
                        case "xesam:title":
                            _state.Title = value.GetString();
                            break;
                    }
                }
                
                await Task.Delay(_state.IsPlaying ? 500 : 2000);
            }
        }
        catch (Exception e)
        {
            #if DEBUG
            Environment.FailFast("bwar", e);
            #endif
        }
    }

    private volatile MediaPlayerState _state = new();
    
    public MediaPlayerState GetState()
    {
        return _state;
    }
}