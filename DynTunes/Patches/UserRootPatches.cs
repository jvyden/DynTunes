using System.Diagnostics.CodeAnalysis;
using FrooxEngine;
using HarmonyLib;

namespace DynTunes.Patches;

[HarmonyPatch(typeof(UserRoot))]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Local")]
[SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract")]
[SuppressMessage("ReSharper", "VariableCanBeNotNullable")]
public class UserRootPatches
{
    private static bool WriteOrAttachDynVar<T>(DynamicVariableSpace space, string name, T value)
    {
        DynamicVariableWriteResult result = space.TryWriteValue(name, value);
        if (result == DynamicVariableWriteResult.NotFound)
        {
            AttachDynVar<T>(space, name);
            result = space.TryWriteValue(name, value);
        }

        return result == DynamicVariableWriteResult.Success;
    }

    private static void AttachDynVar<T>(IComponent root, string name)
    {
        string varName = $"{DynTunes.KeySpace}/{name}";
        DynamicValueVariable<T> variable = root.Slot.GetComponentOrAttach<DynamicValueVariable<T>>(x => x.VariableName.Value == varName);

        variable.VariableName.Value = varName;
        variable.Value.Value = default;
    }
			
    [HarmonyPatch("OnCommonUpdate")]
    [HarmonyPostfix]
    private static void OnCommonUpdate(UserRoot __instance)
    {
        if (__instance == null || __instance.ActiveUser != __instance.LocalUser || __instance.World.IsUserspace()) return;

        DynamicVariableSpace? space = __instance.Slot.FindSpace(DynTunes.KeySpace);
        if (space == null) return;
        
        MediaPlayerState state = DynTunes.Connector.GetState();

        bool failed = false;

        failed |= !WriteOrAttachDynVar(space, DynTunes.KeyPrefix + DynTunes.Title, state.Title);
        failed |= !WriteOrAttachDynVar(space, DynTunes.KeyPrefix + DynTunes.Artist, state.Artist);
        failed |= !WriteOrAttachDynVar(space, DynTunes.KeyPrefix + DynTunes.Album, state.Album);
        failed |= !WriteOrAttachDynVar(space, DynTunes.KeyPrefix + DynTunes.AlbumArtUrl, state.AlbumArtUrl);
        failed |= !WriteOrAttachDynVar(space, DynTunes.KeyPrefix + DynTunes.Playing, state.IsPlaying);
        failed |= !WriteOrAttachDynVar(space, DynTunes.KeyPrefix + DynTunes.Position, state.PositionSeconds);
        failed |= !WriteOrAttachDynVar(space, DynTunes.KeyPrefix + DynTunes.Length, state.LengthSeconds);

        _ = failed; // Todo: warn
    }
}