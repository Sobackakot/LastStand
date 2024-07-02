
using System;
using UnityEngine; 
using UnityEngine.InputSystem;

public class InputControllerCamera : IInputController , IDisposable
{   
    //Rotate and Zoom CameraLookTarget
    public event Action<Vector2> onRotateMouse; //This Event for calss CameraLookTarget
    public event Action<Vector2> onScrollMouse; //This Event for calss CameraLookTarget
    public event Action<Vector2> onInputGetAxis;//This Event for  calss RaycastPointFollow  

    private InputActions inputActions;

    private bool isPressedMiddleMouseButton = false;
    public  InputControllerCamera()
    {
        inputActions = new InputActions();
        inputActions.Enable();

        inputActions.ActionMaps.LookMouseDelta.performed += ctx => LookMouseDelta_performed(ctx);
        inputActions.ActionMaps.ScrollMouse.performed += ctx => ScrollMouse_performed(ctx);

        inputActions.ActionMaps.GetAxisDirectionMove.performed += ctx => RayPointMove_onInputGetAxis(ctx);
        inputActions.ActionMaps.GetAxisDirectionMove.canceled += ctx => RayPointMove_onInputGetAxis(ctx);

        inputActions.ActionMaps.MiddleMouseButton.performed += ctx => isPressedMiddleMouseButton = true;
        inputActions.ActionMaps.MiddleMouseButton.canceled += ctx => isPressedMiddleMouseButton = false;
        
    }

    public void Dispose()
    {
        inputActions.Disable(); 
    }

    private void RayPointMove_onInputGetAxis(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onInputGetAxis?.Invoke(context.ReadValue<Vector2>());//SetInputAxisMove(Vector2 inputAxis) 
        } 
        else onInputGetAxis?.Invoke(Vector2.zero); 
    }
    
    private void LookMouseDelta_performed(InputAction.CallbackContext context)
    {
        if (isPressedMiddleMouseButton && context.performed)
            onRotateMouse?.Invoke(context.ReadValue<Vector2>()); //RotateCamera(Vector2 deltaMouse)
        else onRotateMouse?.Invoke(Vector2.zero);
    }
    private void ScrollMouse_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
            onScrollMouse?.Invoke(context.ReadValue<Vector2>());//ZoomCamera(Vector2 scrollMouse)
        else onScrollMouse?.Invoke(Vector2.zero);
    } 
   
}
