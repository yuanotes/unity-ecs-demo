using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine.EventSystems;

public class MovableSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.
            ForEach((ref PhysicsVelocity physicsVelocity, in Movable mov) => {
                var step = mov.speed * mov.direction;
                physicsVelocity.Linear = step;
            }).Schedule();
    }
}
