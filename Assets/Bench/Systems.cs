/*using Unity.Entities;
using UnityEngine;
using Unity.Transforms;
using System.Runtime.CompilerServices;

public class Sys1 : ComponentSystem
{
    public struct CompGroup
    {
        public readonly ComponentDataArray<Comp1> comp1;
        public readonly int Length;
    }

    [Inject] CompGroup compGroup;

    protected override void OnUpdate()
    {
        var c = 0;
        for (int i = 0; i < compGroup.Length; i++)
        {
            //c++;
            c += compGroup.comp1[i].data;
        }
        if (c != 0)
        {
            Debug.Log("ERROR1");
            return;
        }
    }
}


public class Sys2 : ComponentSystem
{
    public struct CompGroup
    {
        public readonly ComponentDataArray<Comp1> comp1;
        public readonly ComponentDataArray<Comp2> comp2;
        public readonly int Length;
    }

    [Inject] CompGroup compGroup;
    protected override void OnUpdate()
    {
        var c = 0;
        for (int i = 0; i < compGroup.Length; i++)
        {
            c += compGroup.comp1[i].data;
        }
        if (c != 0)
        {
            Debug.Log("ERROR1");
            return;
        }
    }
}

public class Sys3 : ComponentSystem
{
    public struct CompGroup
    {
        public readonly ComponentDataArray<Comp2> comp2;
        public readonly ComponentDataArray<Comp3> comp3;
        public readonly int Length;
    }

    [Inject] CompGroup compGroup;
    protected override void OnUpdate()
    {
        var c = 0;
        for (int i = 0; i < compGroup.Length; i++)
        {
            c += compGroup.comp2[i].data;
        }
        if (c != 0)
        {
            Debug.Log("ERROR1");
            return;
        }
    }
}*/


using Unity.Entities;
using UnityEngine;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Entities.CodeGeneratedJobForEach;

public class Sys1 : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.
            ForEach((ref Comp1 comp1) => {
                comp1.data ++;
            }).Schedule();
    }
}

public class Sys2 : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.
            ForEach((ref Comp1 comp1, ref Comp2 comp2) => {
                comp2.data ++;
                comp1.data ++;
            }).Schedule();
    }
}

public class Sys3 : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.
            ForEach((ref Comp2 comp1, ref Comp3 comp2) => {
                comp2.data ++;
                comp1.data ++;
            }).Schedule();
    }
}
