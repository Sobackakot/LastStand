

using System;
using UnityEngine;

public interface IInputController  
{
    //Rotate and Zoom CameraLookTarget
    event Action<Vector2> onRotateMouse; //This Event for calss CameraLookTarget
    event Action<Vector2> onScrollMouse; //This Event for calss CameraLookTarget
    event Action<Vector2> onInputGetAxis;//This Event for  calss RaycastPointFollow  
}
