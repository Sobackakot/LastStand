 
using Unity.Burst;
using Unity.Entities; 
using Unity.Transforms;
using UnityEngine;
using UnityEngine.AI;

[UpdateBefore(typeof(TransformSystemGroup))]
[UpdateAfter(typeof(GetInputMouse))]
public partial struct MoveSystem : ISystem
{
    EntityQuery m_MoveQuery;

    public void OnCreate(ref SystemState state)
    {
        m_MoveQuery = state.GetEntityQuery(ComponentType.ReadOnly<PointRayCamera>(), ComponentType.ReadWrite<NavMeshAgent>()); 
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        MoveJob moveJob = new MoveJob();
        moveJob.Run();
    }
}
[BurstCompile]
public partial struct MoveJob : IJobEntity
{
    public void Execute(in PointRayCamera pointRay, NavMeshAgent agent)
    {
        if (Physics.Raycast(pointRay.ray, out RaycastHit hit, Mathf.Infinity))
        {
            agent.SetDestination(hit.point);
        }
    }
}
