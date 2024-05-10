
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

    private float deltaX;
    private float deltaY;

    private void OnEnable()
    {
        inputContorlCamera.onRotateMouse += RotateCamera;
        inputContorlCamera.onScrollMouse += ZoomCamera;
        raycastPointFollow.onResetTargetLookPoint += ResetLookPoint;
        
    }
    private void OnDisable()
    {
        inputContorlCamera.onRotateMouse -= RotateCamera;
        inputContorlCamera.onScrollMouse -= ZoomCamera;
        raycastPointFollow.onResetTargetLookPoint -= ResetLookPoint;
        CharacterSwitchingSystem.Instance.onResetFocusCamera -= ResetLookPoint;
    }
    private void Start()
    {
        CharacterSwitchingSystem.Instance.onResetFocusCamera += ResetLookPoint;
        cameraPoint = GetComponent<Transform>();
        currentLookPoint = lookFreePoint;
        offset = cameraPoint.position - currentLookPoint.position; // get the starting position of the camera from the target 
        //Cursor.lockState = CursorLockMode.Locked;
    }
    public void LateUpdate()
    {
        PositionUpdate();
    } 
    private void ResetLookPoint(bool isFreeCamera, PickUpPerson person = null) //call from CharacterSwitchingSystem
    {
        // either the camera follows the character selected from the list or freely follows the point
        if (isFreeCamera)
        {
            currentLookPoint = lookFreePoint;
        } 
        else
        { 
            currentLookPoint = person.transform; 
        }
    }
    public void PositionUpdate()
    {
        cameraPoint.position = cameraPoint.localRotation * offset + currentLookPoint.position;//updating camera position when rotating
        cameraPoint.position = currentLookPoint.position - cameraPoint.forward * currentScrollPoint; //updating camera position when zooming
    }
    private void RotateCamera(Vector2 deltaMouse)
    {
        deltaX += deltaMouse.x * sensitivity; // get the rotation delta along X
        deltaY -= deltaMouse.y * sensitivity; // get rotation delta in Y
        deltaY = Mathf.Clamp(deltaY, minAngle, maxAngle); // rotation limitation in Y
        cameraPoint.localEulerAngles = new Vector3(deltaY, deltaX, 0); // initialize camera rotation only with the button held down
    }
    private void ZoomCamera(Vector2 scrollMouse)
    {   
        currentScrollPoint-= scrollMouse.y * zoomSpeed * Time.deltaTime; // get camera Zoom values ​​forward/backward
        currentScrollPoint = Mathf.Clamp(currentScrollPoint, Mathf.Abs(minZoom), Mathf.Abs(maxZoom)); // Zoom restrictions 
    } 
}
