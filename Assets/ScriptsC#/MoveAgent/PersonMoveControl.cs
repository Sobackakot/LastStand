
using System; 
using UnityEngine;
using UnityEngine.AI;

public class PersonMoveControl : MonoBehaviour
{   
    [Header("Additional components required!!!")]
    [Header("1). InputControlPerson")]
    [Header("2). NavMeshAgent")]
    [Header("3). PersonCamera")]

    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask terraLayer;

    private InputControlPerson inputControllerPerson; 
    private NavMeshAgent agentMove; 

    [Range(100, 1000)] private float rayDistance = 500f;

    private void Awake()
    {
        inputControllerPerson = GetComponent<InputControlPerson>();
        agentMove = GetComponent<NavMeshAgent>();
    }
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
        if (Physics.Raycast(ray, out hit, rayDistance, terraLayer))
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
