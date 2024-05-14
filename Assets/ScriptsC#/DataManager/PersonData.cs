using System;
using UnityEngine;

[Serializable]
public struct PersonData  
{ 
    private string id;
    public string ID { get { return id; } private set { id = value; } }

    private string name;
    public string Namae { get { return name; } set { name = value; } }

    private Sprite sprite;
    public Sprite Sprite { get { return sprite; }set { sprite = value; } }

    [Range(1, 100)]
    private float currentHP;
    public float CurrentHP { get { return currentHP; } set { currentHP = value; } }

    private float x;
    private float y;
    private float z;

    private bool isInstalled;

    public void SetNewPersonId()
    {
        if (!isInstalled)
        {
            id = Guid.NewGuid().ToString();
            isInstalled = true; 
        } 
    }   
    public void SavePositionPerson(ref Transform person)
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
}
