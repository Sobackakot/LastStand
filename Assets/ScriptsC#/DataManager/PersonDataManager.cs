
using System;
using System.Collections.Generic; 
using UnityEngine;

[Serializable]
public class PersonDataManager  
{
    public  List<PersonData> dataPersons = new List<PersonData>(); 
    public void AddDataPerson(PersonData data)
    {   
        if(dataPersons.Contains(data)) return;
        dataPersons.Add(data);
        Debug.Log("Add new PersonData to PersonManager");
    }
    public void RemoveDataPerson(PersonData data)
    {
        if (!dataPersons.Contains(data)) return;
        dataPersons.Remove(data);
        Debug.Log("Remove PersonData from PersonManager");
    } 
}
