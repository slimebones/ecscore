using Scellecs.Morpeh;
using Slimebones.ECSCore.Base.GO;
using Slimebones.ECSCore.React;
using UnityUI = UnityEngine.UI;

namespace Slimebones.ECSCore.Scene
{
    public class ExitButtonListener: IEntityListener
    {
        private Entity e;
        private UnityUI.Button unityButton;
        private World world;

        public void Subscribe(
            Entity e, World world
        )
        {
            this.e = e;
            this.world = world;
            unityButton = GOUtils.GetUnityOrError(
                e
            ).GetComponent<UnityUI.Button>();

            unityButton.onClick.AddListener(Call);
        }

        public void Unsubscribe()
        {
            unityButton.onClick.RemoveListener(Call);
        }

        private void Call()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}