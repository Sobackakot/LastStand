 
using UnityEngine;
using Zenject;

public class PersonFactory : IPersonFactory
{
    
    private readonly DiContainer diContainer;
    private Object person;
    private const string Path = "OtherPerson";

    public PersonFactory(DiContainer diContainer)
    {
        this.diContainer = diContainer;
    }
    public void LoadPersons()
    {
        person = Resources.Load(Path);
    }
    public void CreatePerson(Vector3 point)
    {
        diContainer.InstantiatePrefab(person, point, Quaternion.identity, null);
    } 
}
