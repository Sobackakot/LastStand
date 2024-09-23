 
using UnityEngine;

public class InputMove : IInputMove
{    
    public float Horizontal()
    {
        return Input.GetAxis("Horizontal");
    }
    public float Vertical()
    {
        return Input.GetAxis("Vertical");
    } 
    public bool IsKeyDownSpace()
    {
        return Input.GetKey(KeyCode.Space);
    }
}
