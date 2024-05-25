
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
    private Interactable interactFocus;
    private Transform focusTrnasform;
    private Transform person;
    private float angleSpeed = 5f;

    [Range(100, 1000)] private float rayDistance = 500f;

    private void Awake()
    {
        person = GetComponent<Transform>();
        inputControllerPerson = GetComponent<InputControlPerson>();
        agentMove = GetComponent<NavMeshAgent>();
    }
    private void OnEnable()
    {
        inputControllerPerson.onRightMouseButton += MoveAgent;
        inputControllerPerson.onLeftMouseButton += UpdateFocusInteract;
    } 

    private void OnDisable()
    {
        inputControllerPerson.onRightMouseButton -= MoveAgent;
        inputControllerPerson.onLeftMouseButton -= UpdateFocusInteract;
    }
    private void LateUpdate()
    {
        LookRotationTarget();
        FolowFocus();
    }
    private void MoveAgent()
    {    
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance, terraLayer))
        {
            agentMove.SetDestination(hit.point);
            RemoveFocus();
        } 
    } 
    private void UpdateFocusInteract()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {    
            Interactable interactable =  hit.collider.GetComponent<Interactable>(); 
            if (interactable != null)
            {
                SetFocus(interactable); 
            }
        }
    }
    private void LookRotationTarget()
    {   
        if(focusTrnasform != null)
        { 
            Vector3 newDirection = (focusTrnasform.position - person.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(newDirection.x, 0, newDirection.z));
            person.rotation = Quaternion.Lerp(person.rotation, lookRotation, angleSpeed * Time.deltaTime);
        } 
    }
    private void FolowFocus()
    {
        if (interactFocus != null)
        {
            agentMove.SetDestination(focusTrnasform.position);
            agentMove.stoppingDistance = interactFocus.radius;
        }  
    }
    private void SetFocus(Interactable newFocus)
    {   
        if(newFocus != interactFocus)
        {   
            if(interactFocus != null)
                interactFocus.OnDefocus();
            interactFocus = newFocus;
            focusTrnasform = newFocus.transform; 
        }
        newFocus.OnFocused(person); 
    }
    private void RemoveFocus()
    {
        if (interactFocus != null)
            interactFocus.OnDefocus();  
        interactFocus = null;
        focusTrnasform = null;
        agentMove.stoppingDistance =0; 
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
