using System; 
using UnityEngine;
using UnityEngine.InputSystem;

public class InputGameController : MonoBehaviour // TEST
{ 
    public event Action onLeftMouseButtonDown;  
    public event Action onPressedMouseButton; 
    public event Action onLeftMouseButtonUp;  
      
    private InputActions inputActions;
    private bool isPressedLeftMouseButton;

    private void OnEnable()
    {
        inputActions = new InputActions();
        inputActions.Enable();
        inputActions.ActionMaps.LeftMouseButton.performed += ctx => LeftMouse_Performed(ctx);
        inputActions.ActionMaps.LeftMouseButton.canceled += ctx => LeftMouse_Canceled(ctx);

        inputActions.ActionMaps.SelectMouseDelta.performed += ctx => SelectMouseDelta_Perfomed(ctx); 
        inputActions.ActionMaps.LeftMouseButton.performed += ctx => isPressedLeftMouseButton = true;
        inputActions.ActionMaps.LeftMouseButton.canceled += ctx => isPressedLeftMouseButton = false; 
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
    private void LeftMouse_Performed(InputAction.CallbackContext context)
    {
        if (context.performed)
            onLeftMouseButtonDown?.Invoke(); 
    }
    private void SelectMouseDelta_Perfomed(InputAction.CallbackContext context)
    {
        if (isPressedLeftMouseButton && context.performed)
            onPressedMouseButton?.Invoke();
    }
    private void LeftMouse_Canceled(InputAction.CallbackContext context)
    {
        if (context.canceled)
            onLeftMouseButtonUp?.Invoke(); 
    } 
}
