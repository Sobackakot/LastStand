 
using UnityEngine;
using UnityEngine.AI;

public class MoveAgentHitPoint : MonoBehaviour
{
    [SerializeField] private InputControlPerson inputControllerPerson;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private NavMeshAgent agentMove;
    [SerializeField, Range(100, 1000)] private float rayDistance = 150f;
    private void OnEnable()
    {
        inputControllerPerson.onRightMouseButton += MoveAgent;
    }
    private void OnDisable()
    {
        inputControllerPerson.onRightMouseButton -= MoveAgent;
    }
    public void EnableMoveAgent()
    {
        enabled = true;
    }
    public void DisableMoveAgent()
    {
        enabled = false;
    }
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
