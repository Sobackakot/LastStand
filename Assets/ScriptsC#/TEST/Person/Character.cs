 
using UnityEngine;

public class Character : MonoBehaviour, ICharacter
{ 

    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Jump(bool isKeyDown)
    {
        if (isKeyDown)
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }
    public void Move(float horizontal, float vecrtical)
    {   
        Vector3 axis = new Vector3(horizontal, 0,vecrtical);
        rb.MovePosition(rb.position + axis * 10 * Time.deltaTime);
    }
}
