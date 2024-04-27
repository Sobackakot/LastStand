 
using Unity.Entities; 
using UnityEngine;
using UnityEngine.InputSystem;


[UpdateInGroup(typeof(InitializationSystemGroup), OrderLast =true)]
public partial class GetInputMouse : SystemBase
{
    private InputActions inputActions;
    private Camera _mainCamera;
    private Ray _ray;
    protected override void OnCreate()
    { 
        RequireForUpdate<PointRayCamera>(); 
        inputActions = new InputActions();
        _mainCamera = Camera.main;
    }
    protected override void OnStartRunning()
    {
        inputActions.Enable();
    }
    protected override void OnStopRunning()
    {
        inputActions.Disable();
    }
    protected override void OnUpdate()
    {
        if (inputActions.ActionMaps.LeftMouse.triggered)
        {    
            Vector2 newMousePoint = Mouse.current.position.ReadValue();
            _ray = _mainCamera.ScreenPointToRay(newMousePoint);
            SystemAPI.SetSingleton(new PointRayCamera
            { 
                ray = _ray
            });
        }
    }
}
