 
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputContorller : MonoBehaviour
{
    [SerializeField] private UnityEvent onLeftMouseButton;
    [SerializeField] private UnityEvent onRightMouseButton; 

    [SerializeField] private UnityEvent<Vector2> onLookMouseDelta;
    [SerializeField] private UnityEvent<Vector2> onScrollMouse;
     
    private InputActions inputActions;

    private bool isPressedMouseButton = false;

    private void OnEnable()
    {
        inputActions = new InputActions();
        inputActions.Enable();
        inputActions.ActionMaps.LeftMouseButton.performed += ctx => LeftMouse_performed(ctx);
        inputActions.ActionMaps.RightMouseButton.performed += ctx => RightMouse_performed(ctx);
        inputActions.ActionMaps.LookMouseDelta.performed += ctx => LookMouseDelta_performed(ctx);
        inputActions.ActionMaps.ScrollMouse.performed += ctx => ScrollMouse_performed(ctx);
        inputActions.ActionMaps.MiddleMouseButton.performed += ctx => isPressedMouseButton = true;
        inputActions.ActionMaps.MiddleMouseButton.canceled += ctx => isPressedMouseButton = false;
    }
    private void OnDisable()
    {
        inputActions.Disable();
    } 
    
    private void LeftMouse_performed(InputAction.CallbackContext context)
    {   
        if(context.performed)
            onLeftMouseButton.Invoke();
    }
    private void RightMouse_performed(InputAction.CallbackContext context)
    {   
        if(context.performed)
            onRightMouseButton.Invoke();
    } 
    private void LookMouseDelta_performed(InputAction.CallbackContext context)
    {
        if (isPressedMouseButton && context.performed)
        {   
            Vector2 deltaMouse = inputActions.ActionMaps.LookMouseDelta.ReadValue<Vector2>();
            onLookMouseDelta.Invoke(deltaMouse);
        } 
    }
    private void ScrollMouse_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 scrollMouse = inputActions.ActionMaps.ScrollMouse.ReadValue<Vector2>();
            onScrollMouse.Invoke(scrollMouse);
        } 
    }

}
