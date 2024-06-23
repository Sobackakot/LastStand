
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

// This class controls the movement of a person in the game.
public class PersonMoveControl : MonoBehaviour
{ 
    [Header("Additional components required!!!")]
    [Header("1). InputControlPerson")]
    [Header("2). NavMeshAgent")]
    [Header("3). PersonCamera")]
     
    [SerializeField] private Camera mainCamera;  
    [SerializeField] private LayerMask terraLayer; // Layer mask for the terrain.

    private InputControlPerson inputControllerPerson;  
    private NavMeshAgent agentMove; 
    private Interactable interactFocus; // Current interactable object in focus.
    private Transform focusTrnasform; // Transform of the current focus.
    private Transform person; // Transform of the person.
    private float angleSpeed = 5f; // Speed of rotation towards the focus.
    private bool isPointerEnterUI = false; //whether the mouse cursor is on the UI

    [Range(100, 1000)] private float rayDistance = 500f; // Distance for raycasting.
     
    private void Awake()
    {
        person = GetComponent<Transform>(); 
        inputControllerPerson = GetComponent<InputControlPerson>(); 
        agentMove = GetComponent<NavMeshAgent>(); 
    }

    
    private void OnEnable()
    {
        inputControllerPerson.onRightMouseButton += MoveAgent; // Subscribe to the right mouse button event.
        inputControllerPerson.onLeftMouseButton += UpdateFocusInteract; // Subscribe to the left mouse button event.
        OnPointerEnterUI.onPointerEnterUI += IsPointerEnterUI; //checking whether the mouse cursor is on the UI
        isPointerEnterUI = false; // Reset flage
    }

    
    private void OnDisable()
    {
        inputControllerPerson.onRightMouseButton -= MoveAgent; // Unsubscribe from the right mouse button event.
        inputControllerPerson.onLeftMouseButton -= UpdateFocusInteract; // Unsubscribe from the left mouse button event.
        OnPointerEnterUI.onPointerEnterUI -= IsPointerEnterUI; //checking whether the mouse cursor is on the UI
        isPointerEnterUI = true; // Reset flage
    }

    
    private void LateUpdate()
    { 
        LookRotationTarget(); // Rotate towards the focus target.
        FolowFocus(); // Follow the focus target.
    }
    private void  IsPointerEnterUI(bool isEnterUi) // coll from OnPointerEnterUI
    {
        isPointerEnterUI = isEnterUi; // Set flage  
    }

    // Method to move the agent to the clicked position.
    private void MoveAgent()// coll from class InputControlPerson
    {
        if (isPointerEnterUI) return; //checking that the mouse cursor does not fall into ui elements
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()); // Create a ray from the camera through the mouse position.
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance, terraLayer))
        {
            agentMove.SetDestination(hit.point); // Set the agent's destination to the hit point.
            RemoveFocus(); // Remove the current focus.
        }
    }

    // Method to update the focus to an interactable object.
    private void UpdateFocusInteract() // coll from class InputControlPerson
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()); // Create a ray from the camera through the mouse position.
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>(); // Get the interactable component from the hit object.
            if (interactable != null)
            {
                SetFocus(interactable); // Set the new focus to the interactable object.
            }
        }
    }

    // Method to rotate the person towards the focus target.
    private void LookRotationTarget()
    {
        if (focusTrnasform != null)
        {
            Vector3 newDirection = (focusTrnasform.position - person.position).normalized; // Calculate the direction to the focus target.
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(newDirection.x, 0, newDirection.z)); // Calculate the rotation towards the focus target.
            person.rotation = Quaternion.Lerp(person.rotation, lookRotation, angleSpeed * Time.deltaTime); // Smoothly rotate towards the focus target.
        }
    }

    // Method to follow the focus target.
    private void FolowFocus()
    {
        if (interactFocus != null)
        {
            StopedDistance(); // Check if the agent should stop.
            agentMove.SetDestination(focusTrnasform.position); // Set the agent's destination to the focus target.
        }
    }

    // Method to stop the agent if it is close enough to the focus target.
    private void StopedDistance()
    {
        float distance = Vector3.Distance(person.position, focusTrnasform.position); // Calculate the distance to the focus target.
        if (distance < interactFocus.radius)
        {
            agentMove.velocity = Vector3.zero; // Stop the agent's movement.
        }
    }

    // Method to set the focus to a new interactable object.
    private void SetFocus(Interactable newFocus)
    {
        if (newFocus != interactFocus) //if the selected item is not equal to the current one
        {
            if (interactFocus != null)
                interactFocus.OnDefocus(); // Defocus the previous interactable object.
            interactFocus = newFocus; //change to new focus
            focusTrnasform = newFocus.transform; // Set the new focus transform.
        }
        newFocus.OnFocused(person); // Notify the new interactable object that it is focused.
    }

    // Method to remove the current focus.
    private void RemoveFocus()
    {
        if (interactFocus != null)
            interactFocus.OnDefocus(); // Defocus the current interactable object.
        interactFocus = null;
        focusTrnasform = null; // Clear the focus transform.
    }

    // Method to enable the component.
    public void OnEnableComponent()  //coll from class CharacterSwitchSystem
    {
        enabled = true;
    }

    // Method to disable the component.
    public void OnDisableComponent() //coll from class CharacterSwitchSystem
    {
        enabled = false;
    }
} 
