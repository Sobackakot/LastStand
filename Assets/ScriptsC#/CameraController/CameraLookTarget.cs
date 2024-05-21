﻿
using System; 
using UnityEngine; 

public class CameraLookTarget : MonoBehaviour  
{
    [Header("EventSystem Camera Input Contoller")]
    [SerializeField] private InputContorlCamera inputContorlCamera;
    [Header("EventSystem RaycastPointFollow")]
    [SerializeField] private RaycastPointFollow raycastPointFollow;

    [Header("Transform: Target Look Point")]
    [SerializeField] private Transform lookFreePoint; 
    [Header("Current Camera position")]
    [SerializeField] private Vector3 offset; 
     
    [Range(0.3f,3)] private float sensitivity = 0.5f;
    [Range(-75, 0)] private float minAngle = -45f;
    [Range(0, 75)] private float maxAngle = 75f;

    [Range(1,30)] private float currentScrollPoint = 6f;
    [Range(1, 10)] private float zoomSpeed = 2f;
    [Range(1, 6)] private float minZoom = 2f;
    [Range(25, 500)] private float maxZoom = 100f;
      
    private Transform cameraPoint;// camera starting position
    private Transform currentLookPoint; // current camera tracking point

    public event Action<Transform> onUpdateRaycastPoint;

    private float deltaX;
    private float deltaY;

    private Transform newTransformRaycast;

    private void OnEnable()
    {
        inputContorlCamera.onRotateMouse += RotateCamera; // InputControllerCamera
        inputContorlCamera.onScrollMouse += ZoomCamera;// InputControllerCamera
        raycastPointFollow.onResetTargetLookPoint += ResetLookPoint; //RaycastPointFollow

    }
    private void OnDisable()
    {
        inputContorlCamera.onRotateMouse -= RotateCamera;// InputControllerCamera
        inputContorlCamera.onScrollMouse -= ZoomCamera;// InputControllerCamera
        raycastPointFollow.onResetTargetLookPoint -= ResetLookPoint;//RaycastPointFollow
        CharacterSwitchSystem.Instance.onResetFocusCamera -= ResetLookPoint;
    }
    private void Start()
    {
        CharacterSwitchSystem.Instance.onResetFocusCamera += ResetLookPoint;
        cameraPoint = GetComponent<Transform>();
        currentLookPoint = lookFreePoint;
        offset = cameraPoint.position - currentLookPoint.position; // get the starting position of the camera from the target  
    }
    public void LateUpdate()
    {
        PositionUpdate(); 
    } 
    private void ResetLookPoint(bool isFreeCamera, PickUpPerson person = null) //call from CharacterSwitchSystem
    {
        // either the camera follows the character selected from the list or freely follows the point
        if (isFreeCamera)
        { 
            UpdateRaycastPoint();
            currentLookPoint = lookFreePoint; 
        } 
        else
        {   
            currentLookPoint = person.transform;
            newTransformRaycast = person.transform;
        }
    }
   
    private void UpdateRaycastPoint()
    {
        //Updates the raycast position depending on the position of the selected Character
        if (newTransformRaycast != null)
        {
            onUpdateRaycastPoint?.Invoke(newTransformRaycast); //gets new coordinates for Raycast
            newTransformRaycast = null;
        }
    }
    public void PositionUpdate()
    {
        //updating camera position when rotating
        cameraPoint.position = cameraPoint.localRotation * offset + currentLookPoint.position;
        //updating camera position when zooming
        cameraPoint.position = currentLookPoint.position - cameraPoint.forward * currentScrollPoint; 
    }
    private void RotateCamera(Vector2 deltaMouse)
    {    
        deltaX += deltaMouse.x * sensitivity; // get the rotation delta along X
        deltaY -= deltaMouse.y * sensitivity; // get rotation delta in Y
        deltaY = Mathf.Clamp(deltaY, minAngle, maxAngle); // rotation limitation in Y
        // initialize camera rotation only with the button held down
        cameraPoint.localEulerAngles = new Vector3(deltaY, deltaX, 0); 
    }
    private void ZoomCamera(Vector2 scrollMouse)
    {   
        currentScrollPoint-= scrollMouse.y * zoomSpeed * Time.deltaTime; // get camera Zoom values ​​forward/backward
        currentScrollPoint = Mathf.Clamp(currentScrollPoint, Mathf.Abs(minZoom), Mathf.Abs(maxZoom)); // Zoom restrictions 
    } 
}
