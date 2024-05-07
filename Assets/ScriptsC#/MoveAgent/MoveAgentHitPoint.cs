 
using UnityEngine;
using UnityEngine.AI;

public class MoveAgentHitPoint : MonoBehaviour, ICharacterComponent
{
    [SerializeField] private InputControlPerson inputControllerPerson;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private NavMeshAgent agentMove;
    [Range(100, 1000)] private float rayDistance = 500f;
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

    public ICharacterComponent GetComponent()
    {
        throw new System.NotImplementedException();
    }

    public void OnEnableComponent()
    {
        throw new System.NotImplementedException();
    }

    public void OnDisableComponent()
    {
        throw new System.NotImplementedException();
    }
} 
