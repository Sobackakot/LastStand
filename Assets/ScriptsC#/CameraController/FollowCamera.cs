
using UnityEngine;
using Zenject;

public class FollowCamera : MonoBehaviour
{
    private CharacterSwitchSystem characrterSwitch;

    private Transform raycastPosition;
 
    private Transform currentTarget;
    private Transform transformPoint;
    private float maxRadius = 50f;
    private float smoothSpeed = 1f;
    private Vector3 direction;

    [Inject]
    private void Construct([Inject(Id = "personTarget")] Transform personTransform, CharacterSwitchSystem characrterSwitch, [Inject(Id = "raycastPoint")]Transform raycastPosition)
    {
        currentTarget = personTransform;
        this.characrterSwitch = characrterSwitch;
        this.raycastPosition = raycastPosition;
    }
    private void Awake()
    {
        transformPoint = GetComponent<Transform>(); 
    }
    private void OnDisable()
    {
        characrterSwitch.onSetNewTargetFolowCamera -= SetTargetPlayer;
    }
    private void Start()
    {
        characrterSwitch.onSetNewTargetFolowCamera += SetTargetPlayer;
    }
    private void LateUpdate()
    {
        RadiusCameraClamp(); 
    }
    public void SetTargetPlayer(Transform newTarget) // call from CharacterSwitchSystem
    {
        currentTarget = newTarget;
    }
    private void RadiusCameraClamp() //limiting the radius of free camera movement around the selected character
    { 
        direction = transformPoint.position - currentTarget.position;
        if (direction.sqrMagnitude > maxRadius * maxRadius)
        {
            direction.Normalize();
            direction = Vector3.ClampMagnitude(direction, maxRadius);
            Vector3 currentOffsetY = new Vector3(currentTarget.position.x + direction.x, raycastPosition.position.y, currentTarget.position.z + direction.z);
            raycastPosition.position = Vector3.Lerp(raycastPosition.position, currentOffsetY, Time.deltaTime * smoothSpeed);
        }
    }
}
