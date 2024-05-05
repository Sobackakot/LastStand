
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputContorller : MonoBehaviour
{   
    [Header("Input Mouse Button MoveAgentHitPoint")]

    [SerializeField] private UnityEvent onLeftMouseButton; //This Event for calss MoveAgentHitPoint
    [SerializeField] private UnityEvent onRightMouseButton; //This Event for calss MoveAgentHitPoint

    [Header("Rotate and Zoom CameraLookTarget")]

    [SerializeField] private UnityEvent<Vector2> onRotateMouse; //This Event for calss CameraLookTarget
    [SerializeField] private UnityEvent<Vector2> onScrollMouse; //This Event for calss CameraLookTarget

    [Header("Input Keyboard CharacterAnimatorControl")]

    [SerializeField] private UnityEvent onCtrlButton; //This Event for calss CharacterAnimatorController
    [SerializeField] private UnityEvent onSpaceButton;//This Event for calss CharacterAnimatorController
      
    [SerializeField] private RaycastPointFollow rayPointMove;  

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
        rayPointMove.onInputGetAxis += RayPointMove_onInputGetAxis; //SetInputAxisMove(Vector2 inputAxis)
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
    public Vector2 RayPointMove_onInputGetAxis() //coll from calss RaycastPointFollow
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
            onRightMouseButton.Invoke();//MoveAgent()
    } 
    private void LookMouseDelta_performed(InputAction.CallbackContext context)
    {
        if (isPressedMiddleMouseButton && context.performed)
        {   
            Vector2 deltaMouse = inputActions.ActionMaps.LookMouseDelta.ReadValue<Vector2>();
            onRotateMouse.Invoke(deltaMouse); //RotateCamera(Vector2 deltaMouse)
        } 
    }
    private void ScrollMouse_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 scrollMouse = inputActions.ActionMaps.ScrollMouse.ReadValue<Vector2>();
            onScrollMouse.Invoke(scrollMouse);//ZoomCamera(Vector2 scrollMouse)
        } 
    } 
    private void CtrlButton_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
            onCtrlButton.Invoke(); //WalkSittingAnim()
    }
    private void SpaceButton_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
            onSpaceButton.Invoke(); //MoveStandingAnim()
    }  
}
