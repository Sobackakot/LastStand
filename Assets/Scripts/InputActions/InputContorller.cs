
using System;
using UnityEngine;
using UnityEngine.Events;

public class InputContorller : MonoBehaviour
{
    [SerializeField] private UnityEvent onLeftMouseClick;
    [SerializeField] private UnityEvent onRightMouseClick;
    [SerializeField] private UnityEvent<Vector2> onLookMouse;
    [SerializeField] private UnityEvent<Vector2> onScrollMouse;

    private InputActions inputActions;

    private void OnEnable()
    {
        inputActions = new InputActions();
        inputActions.Enable();
        inputActions.ActionMaps.LeftMouse.performed += ctx => LeftMouse_performed();
        inputActions.ActionMaps.RightMouse.performed += ctx => RightMouse_performed();
        inputActions.ActionMaps.LookMouse.performed += ctx => LookMouseDelta_performed();
        inputActions.ActionMaps.ScrollMouse.performed += ctx => ScrollMouse_performed();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void ScrollMouse_performed()
    {
        Vector2 scrollMouse = inputActions.ActionMaps.ScrollMouse.ReadValue<Vector2>();
        onScrollMouse.Invoke(scrollMouse);
    }

    private void LookMouseDelta_performed()
    {
        Vector2 deltaMouse = inputActions.ActionMaps.LookMouse.ReadValue<Vector2>();
        onLookMouse.Invoke(deltaMouse);
    } 
    private void LeftMouse_performed()
    {
        onLeftMouseClick.Invoke();
    }
    private void RightMouse_performed()
    {
        onRightMouseClick.Invoke();
    }
     
}
