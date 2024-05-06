
using System;
using UnityEngine; 
using UnityEngine.InputSystem;

public class InputControlPerson : MonoBehaviour
{
    //Input Mouse Button MoveAgentHitPoint
    public event Action onLeftMouseButton; //This Event for calss MoveAgentHitPoint
    public event Action onRightMouseButton; //This Event for calss MoveAgentHitPoint

    //Input Keyboard CharacterAnimatorControl
    public event Action onCtrlButton; //This Event for calss CharacterAnimatorController
    public event Action onSpaceButton;//This Event for calss CharacterAnimatorController

    private InputActions inputActions;

    private void OnEnable()
    {
        inputActions = new InputActions();
        inputActions.Enable();
        inputActions.ActionMaps.LeftMouseButton.performed += ctx => LeftMouse_performed(ctx);
        inputActions.ActionMaps.RightMouseButton.performed += ctx => RightMouse_performed(ctx);  
        inputActions.ActionMaps.CtrlButton.performed += ctx => CtrlButton_performed(ctx);
        inputActions.ActionMaps.SpaceButton.performed += ctx => SpaceButton_performed(ctx); 
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
    public void EnableInputController()
    {
        enabled = true;
    }
    public void DisableInputController()
    {
        enabled = false;
    }
    private void LeftMouse_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
            onLeftMouseButton?.Invoke();
    }
    private void RightMouse_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
            onRightMouseButton?.Invoke();//MoveAgent()
    }
    private void CtrlButton_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
            onCtrlButton?.Invoke(); //WalkSittingAnim()
    }
    private void SpaceButton_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
            onSpaceButton?.Invoke(); //MoveStandingAnim()
    }
}
