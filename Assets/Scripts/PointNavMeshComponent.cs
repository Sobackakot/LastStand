 
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PointNavMeshComponent : MonoBehaviour
{
    private Vector3 newPoint;
    public float velocity;
    class Baker : Baker<PointNavMeshComponent>
    {
        public override void Bake(PointNavMeshComponent authoring)
        { 
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new PointNavMesh
            {
                newPoint = authoring.newPoint,
                velocity = authoring.velocity,
            });
        }
    } 
}
public struct PointNavMesh: IComponentData
{
    public float3 newPoint;
    public float velocity;
}