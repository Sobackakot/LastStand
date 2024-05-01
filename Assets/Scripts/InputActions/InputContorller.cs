 
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputContorller : MonoBehaviour
{
    [Header("Input Mouse Button")]

    [SerializeField] private UnityEvent onLeftMouseButton;
    [SerializeField] private UnityEvent onRightMouseButton;

    [Header("Rotate Mouse and Zoom")]

    [SerializeField] private UnityEvent<Vector2> onRotateMouse;
    [SerializeField] private UnityEvent<Vector2> onScrollMouse;

    [Header("Input Keyboard")]

    [SerializeField] private UnityEvent onCtrlButton;
    [SerializeField] private UnityEvent onSpaceButton;

    private InputActions inputActions;

    private bool isPressedMiddleMouseButton = false; 

    private void OnEnable()
    {
        inputActions = new InputActions();
        inputActions.Enable();
        inputActions.ActionMaps.LeftMouseButton.performed += ctx => LeftMouse_performed(ctx);
        inputActions.ActionMaps.RightMouseButton.performed += ctx => RightMouse_performed(ctx);
        inputActions.ActionMaps.LookMouseDelta.performed += ctx => LookMouseDelta_performed(ctx);
        inputActions.ActionMaps.ScrollMouse.performed += ctx => ScrollMouse_performed(ctx);
        inputActions.ActionMaps.MiddleMouseButton.performed += ctx => isPressedMiddleMouseButton = true;
        inputActions.ActionMaps.MiddleMouseButton.canceled += ctx => isPressedMiddleMouseButton = false;

        inputActions.ActionMaps.CtrlButton.performed += ctx => CtrlButton_performed(ctx);
        inputActions.ActionMaps.SpaceButton.performed += ctx => SpaceButton_performed(ctx);
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
        if (isPressedMiddleMouseButton && context.performed)
        {   
            Vector2 deltaMouse = inputActions.ActionMaps.LookMouseDelta.ReadValue<Vector2>();
            onRotateMouse.Invoke(deltaMouse);
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
    private void CtrlButton_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
            onCtrlButton.Invoke();
    }
    private void SpaceButton_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
            onSpaceButton.Invoke();
    }
}
