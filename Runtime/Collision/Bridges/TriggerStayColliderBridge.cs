using Scellecs.Morpeh;
using Slimebones.ECSCore.Base.Bridge;
using Slimebones.ECSCore.Base.Event;
using UnityEngine;

namespace Slimebones.ECSCore.Collision.Bridges
{
    /// <summary>
    /// Bridge between Unity Collisions and ECS.
    /// </summary>
    public class TriggerStayColliderBridge: BaseColliderBridge
    {
        public void OnTriggerStay(UnityEngine.Collider collider)
        {
            ref CollisionEvent collisionEvent =
                ref InternalCollisionUtils.CreateTriggerCollisionEvent(
                    collider,
                    Entity,
                    hostCollider,
                    world
                );
            collisionEvent.type = CollisionEventType.Stay;
        }
    }
}
