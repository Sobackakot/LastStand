 
using UnityEngine;
using UnityEngine.AI;

public class MoveAgentHitPoint : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private NavMeshAgent agentMove;
    [SerializeField, Range(100, 1000)] private float rayDistance = 150f;
    
    public void MoveAgent()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            agentMove.SetDestination(hit.point);
        }
    }
} 
