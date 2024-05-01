 
using UnityEngine;
using UnityEngine.AI;

public class MoveAgentHitPoint : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private NavMeshAgent agentMove; 
    public void MoveAgent()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            agentMove.SetDestination(hit.point);
        }
    }
} 
