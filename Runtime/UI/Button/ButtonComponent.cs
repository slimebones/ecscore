using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using Slimebones.ECSCore.Utils;
using System;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Slimebones.ECSCore.UI.Button
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class ButtonComponent: MonoProvider<Button>
    {
    }

    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct Button: IComponent, IDisposable
    {
        [SerializeReference]
        public IListener[] listeners;

        public void Dispose()
        {
            // TODO(ryzhovalex):
            //      No unsubscribe is made for now due to new UI system.
            //      In future consider listening for panel re-enables
            //      and take re-subs accordingly.
            //
            //foreach (var listener in listeners)
            //{
            //    listener.Unsubscribe();
            //}
        }
    }
}