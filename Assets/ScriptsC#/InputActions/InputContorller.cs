
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputContorller : MonoBehaviour
{   
    [Header("Input Mouse Button MoveAgentHitPoint")]

    [SerializeField] private UnityEvent onLeftMouseButton;
    [SerializeField] private UnityEvent onRightMouseButton; //MoveAgent()

    [Header("Rotate and Zoom CameraPerson")]

    [SerializeField] private UnityEvent<Vector2> onRotateMouse; //RotateCamera(Vector2 deltaMouse)
    [SerializeField] private UnityEvent<Vector2> onScrollMouse; //ZoomCamera(Vector2 scrollMouse)

    [Header("Input Keyboard AnimationControl")]

    [SerializeField] private UnityEvent onCtrlButton; //WalkSittingAnim()
    [SerializeField] private UnityEvent onSpaceButton; //MoveStandingAnim()

    //Event from class CameraRayPointMove
    [SerializeField] private CameraRayPointMove rayPointMove; //SetInputAxisMove(Vector2 inputAxis) 

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
        rayPointMove.onInputGetAxis += RayPointMove_onInputGetAxis;
    }
     

    private void OnDisable()
    {
        inputActions.Disable();
    }
    public Vector2 RayPointMove_onInputGetAxis()
    {
        Vector2 inputAxis = inputActions.ActionMaps.GetAxisDirectionMove.ReadValue<Vector2>();
        return inputAxis;
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
