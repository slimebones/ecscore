using Scellecs.Morpeh;

namespace Slimebones.ECSCore.Controller
{
    public interface IController
    {
        public void Init(World world);
        public void Update(float timeDelta, Entity e);
    }
}