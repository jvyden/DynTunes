using System.Text.Json;
using DynTunes.Connectors;

IMusicConnector connector = new MPRISMusicConnector();

JsonSerializerOptions config = new()
{
    WriteIndented = true,
};

while (!Console.KeyAvailable)
{
    Console.Clear();
    Console.WriteLine(JsonSerializer.Serialize(connector.GetState(), config));
    await Task.Delay(16);
}