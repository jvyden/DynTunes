# DynTunes

A [ResoniteModLoader](https://github.com/resonite-modding-group/ResoniteModLoader) mod for [Resonite](https://resonite.com/) that adds Dynamic Variables to show the music you're listening to.

## Support

DynTunes (for now) only works on Linux with D-Bus installed, using media players that implement the MPRIS specification.
This is most, if not all major media players on Linux.

## Installation
1. Install [ResoniteModLoader](https://github.com/resonite-modding-group/ResoniteModLoader).
1. Place [DynTunes.dll](https://github.com/jvyden/DynTunes/releases/latest/download/DynTunes.dll) into your `rml_mods` folder. This folder should be at `C:\Program Files (x86)\Steam\steamapps\common\Resonite\rml_mods` for a default install. You can create it if it's missing, or if you launch the game once with ResoniteModLoader installed it will create this folder for you.
1. Place [Tmds.DBus.Protocol.dll](https://github.com/jvyden/DynTunes/releases/latest/download/Tmds.DBus.Protocol.dll) into your `rml_libs` folder. This is in the same location, next to the `rml_mods` folder.
1. Start the game. If you want to verify that the mod is working you can check your Resonite logs.

## Attributions
This heavily references code from [ResoTabbed by NepuShiro](https://github.com/NepuShiro/ResoTabbed), licensed under [MIT](https://github.com/NepuShiro/ResoTabbed/blob/main/LICENSE).