using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonsList : MonoBehaviour
{
    [SerializeField] private List<GameObject> humanoids = new List<GameObject>(36);
    public void AddPerson(GameObject person)
    {
        humanoids.Add(person);
    }
    public void RemovePerson(GameObject person)
    {
        humanoids.Remove(person);
    }

    public GameObject GetPerson(int index)
    {
        return humanoids[index];
    }

    public void SetPerson(GameObject person, int index)
    {
        humanoids[index] = person;
    }
    public void AddAllPersons()
    {
        foreach (GameObject personInfo in humanoids)
        {
            AddPerson(personInfo);
        }
    }
    public void RemoveAllPersons()
    {
        foreach (GameObject personInfo in humanoids)
        {
            RemovePerson(personInfo);
        }
    }
}
