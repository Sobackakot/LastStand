using System;
using UnityEngine;

[Serializable]
public class PersonData  
{
    public string Id;

    [SerializeField, Range(0, 100)]
    public float currentHP = 100f;

    [Header("Position")]
    public float x = 0;
    public float y = 1;
    public float z = 0;

    [Header("Rotation")] 
    public float rotateY;

    public bool isInstalled = false;
     
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
