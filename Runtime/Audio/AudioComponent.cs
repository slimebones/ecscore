using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;

namespace Slimebones.ECSCore.Audio
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class AudioComponent: MonoProvider<Audio>
    {
    }

    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct Audio: IComponent
    {
    }
}
