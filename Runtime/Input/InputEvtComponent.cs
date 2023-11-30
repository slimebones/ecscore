using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using Slimebones.ECSCore.Base.Event;
using Unity.IL2CPP.CompilerServices;

namespace Slimebones.ECSCore.Input
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class InputEvtComponent: MonoProvider<InputEvt>
    {
    }

    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct InputEvt: IEventComponent
    {
        public InputEvtType type;
        /// <summary>
        /// Unique name across all input events for the runtime.
        /// </summary>
        public string name;
    }
}