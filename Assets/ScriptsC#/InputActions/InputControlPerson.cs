
using System;
using UnityEngine; 
using UnityEngine.InputSystem;

public class InputControlPerson : MonoBehaviour
{  
    public event Action onRightMouseButton; //This Event for calss PersonMoveControl
    public event Action onLeftMouseButton; //This Event for calss PersonMoveControl

    //Input Keyboard CharacterAnimatorControl
    public event Action onCtrlButton; //This Event for calss CharacterAnimatorController
    public event Action onSpaceButton;//This Event for calss CharacterAnimatorController  

    public event Action<bool> onActiveInventory;

    private InputActions inputActions;

    private bool isSwitchInventoryActiv = false;

    private void OnEnable()
    {
        inputActions = new InputActions();
        inputActions.Enable();
        inputActions.ActionMaps.LeftMouseButton.performed += ctx => LeftMouseButton_performed(ctx);
        inputActions.ActionMaps.RightMouseButton.performed += ctx => RightMouseButton_performed(ctx); 

        inputActions.ActionMaps.CtrlButton.performed += ctx => CtrlButton_performed(ctx);
        inputActions.ActionMaps.SpaceButton.performed += ctx => SpaceButton_performed(ctx);

        inputActions.ActionMaps.InventoryKey.performed += ctx => InventoryKey_performed(ctx);

    }

    private void InventoryKey_performed(InputAction.CallbackContext context)
    {
        if (context.performed && !isSwitchInventoryActiv)
        {
            onActiveInventory.Invoke(true);
            isSwitchInventoryActiv= true;
        } 
        else
        {
            onActiveInventory.Invoke(false);
            isSwitchInventoryActiv= false;
        }
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void LeftMouseButton_performed(InputAction.CallbackContext context)
    {
            if (context.performed)
            onLeftMouseButton?.Invoke(); //UpdateFocusInteract
    }
    private void RightMouseButton_performed(InputAction.CallbackContext context)
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
    public void OnEnableComponent()
    {
        enabled = true;
    }

    public void OnDisableComponent()
    {
        enabled = false;
    }
}
