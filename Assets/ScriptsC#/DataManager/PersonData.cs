using System;
using UnityEngine;

[Serializable]
public class PersonData  
{
    public string Id;

    [SerializeField, Range(0, 100)]
    public float currentHP = 100f;

    [Header("Position")]
    public float x;
    public float y;
    public float z;

    [Header("Rotation")] 
    public float rotateY;

    public bool isInstalled = false;

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
