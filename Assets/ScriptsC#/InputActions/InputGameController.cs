using System; 
using UnityEngine;
using UnityEngine.InputSystem;

public class InputGameController : MonoBehaviour
{
    //Input Mouse Button PersonMoveControl
    public event Action onLeftMouseButtonDown; //This Event for calss SelectMouse
    public event Action onSelectStayMouseButton;
    public event Action onLeftMouseButtonUp; //This Event for calss SelectMouse
      
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
            onLeftMouseButtonDown?.Invoke(); //SelectPerson
    }
    private void SelectMouseDelta_Perfomed(InputAction.CallbackContext context)
    {
        if (isPressedLeftMouseButton && context.performed)
            onSelectStayMouseButton?.Invoke();
    }
    private void LeftMouse_Canceled(InputAction.CallbackContext context)
    {
        if (context.canceled)
            onLeftMouseButtonUp?.Invoke();//SelectPerson
    } 
}
