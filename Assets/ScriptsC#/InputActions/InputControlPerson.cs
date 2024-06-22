
using System;
using UnityEngine; 
using UnityEngine.InputSystem;

public class InputControlPerson : MonoBehaviour
{  
    public event Action onRightMouseButton; //This Event for calss PersonMoveControl
    public event Action onLeftMouseButton; //This Event for calss PersonMoveControl

    //Input Keyboard CharacterAnimatorControl
    public event Action onCtrlButton; //This Event for class CharacterAnimatorController
    public event Action onSpaceButton;//This Event for class CharacterAnimatorController  

    public static event Action<bool> onActiveInventory; //This Event for class ActivInformationPerson

    private InputActions inputActions;

    private bool isSwitchInventoryActive = false;

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
    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void InventoryKey_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
        { 
            isSwitchInventoryActive = !isSwitchInventoryActive;
            onActiveInventory.Invoke(isSwitchInventoryActive); //Switcher  activate  inventory person
        }
    }

    private void LeftMouseButton_performed(InputAction.CallbackContext context)
    {
            if (context.performed)
            onLeftMouseButton?.Invoke(); // event for metod UpdateFocusInteract()
    }
    private void RightMouseButton_performed(InputAction.CallbackContext context)
    {
            if (context.performed)
            onRightMouseButton?.Invoke();//event for metod MoveAgent()
    }
    private void CtrlButton_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
            onCtrlButton?.Invoke(); //event for metod WalkSittingAnim()
    }
    private void SpaceButton_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
            onSpaceButton?.Invoke(); //event for metod MoveStandingAnim()
    }
    public void OnEnableComponent() //coll from class CharacterSwitchSystem
    {
        enabled = true;
    }

    public void OnDisableComponent()//coll from class CharacterSwitchSystem
    {
        enabled = false;
    }
}
