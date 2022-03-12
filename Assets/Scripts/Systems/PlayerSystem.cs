using UnityEngine;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Physics;

public class PlayerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        Entities.
            WithAll<Player>().
            ForEach((ref Movable mov, in PhysicsVelocity physicsVelocity) => {
            mov.direction = new float3(x, 0, y);
        }).Schedule();
    }
}
