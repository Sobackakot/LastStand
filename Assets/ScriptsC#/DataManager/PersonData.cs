using System;
using UnityEngine;

[Serializable]
public class PersonData  
{ 
    private string id; 
    public string ID { get { return id; } private set { id = value; } } // use from class PickUpPerson, PickUpPersonUI
     
    [Range(1, 100)]
    private float currentHP;
    public float CurrentHP { get { return currentHP; } set { currentHP = value; } }

    private float x;
    private float y;
    private float z;

    private bool isInstalled;
    
    public void SetNewPersonId() //coll from class CharacterSwitchSystem
    {
        if (!isInstalled) //set unique id
        {
            this.id = Guid.NewGuid().ToString();
            isInstalled = true; 
        } 
    }   
    public void SavePositionPerson(Vector3 position) // coll from class PersonDataManager
    {
        x = position.x;
        y = position.y;
        z = position.z;
    }
    public Vector3 LoadPositionPerson()// coll from class PersonDataManager
    { 
        return new Vector3(x, y, z);
    }
}
