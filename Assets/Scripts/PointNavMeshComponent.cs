 
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PointNavMeshComponent : MonoBehaviour
{ 
    class Baker : Baker<PointNavMeshComponent>
    {
        public override void Bake(PointNavMeshComponent authoring)
        { 
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new PointRayCamera()); 
        }
    } 
}
public struct PointRayCamera: IComponentData
{ 
    public Ray ray;
} 