using System;
using UnityEngine;

[Serializable]
public class PersonData  
{
    private string Id;
    [Range(1,100)]
    private float currentHP = 100f;
     
    private float x = 0;
    private float y = 1;
    private float z = 0;
     
    private float rotateY;

    private bool isInstalled = false;
     
    public void SavePositionPerson(Transform person)
    {
        x = person.position.x;
        y = person.position.y;
        z = person.position.z;
    }
    public Vector3 LoadPositionPerson()
    {    
        float _x = x;
        float _y = y;
        float _z = z;
        return new Vector3(_x, _y, _z);
    }
    public string GetCurrenPersonId()
    {
        if (!isInstalled)
        {
            Id = Guid.NewGuid().ToString();
            isInstalled = true; 
        }
        return Id;
    }
}
