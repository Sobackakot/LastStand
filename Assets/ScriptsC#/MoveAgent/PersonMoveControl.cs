
using System; 
using UnityEngine;
using UnityEngine.AI;

public class PersonMoveControl : MonoBehaviour
{
    [SerializeField] private InputControlPerson inputControllerPerson;
    [SerializeField] private FollowCamera followCameraLookTarget; 
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
    private void MoveAgent()
    {    
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            agentMove.SetDestination(hit.point);
        } 
    } 
    public void OnEnableComponent()
    {
        enabled = true; 
    }

    public void OnDisableComponent()
    {
        enabled = false; 
    }
} 
