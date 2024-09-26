

using System;
using System.Collections.Generic; 
using Zenject;

public class PersonsDataList :  IInitializable, IDisposable
{
    private PersonsDataList(CharacterSwitchSystem characrterSwitch)
    {
        this.characrterSwitch = characrterSwitch;
    }
    private CharacterSwitchSystem characrterSwitch;

    public  List<PersonData> dataPersons = new List<PersonData>();//list of active characters for the save system
 
    
    private void AddDataPerson(PersonData data) // add new person for PersonsDataList from CharacterSwitchSystem
    {
        if (dataPersons.Contains(data)) return;
        dataPersons.Add(data);
    }
    private void RemoveDataPerson(PersonData data) //remove person from PersonsDataList from CharacterSwitchSystem...
    {
        if (dataPersons.Contains(data)) return;
        dataPersons.Remove(data);
    }

    public void Initialize()
    {
        characrterSwitch.onAddNewDataPerson += AddDataPerson;
        characrterSwitch.onRemoveNewDataPerson += RemoveDataPerson;
    }

    public void Dispose()
    {
        characrterSwitch.onAddNewDataPerson -= AddDataPerson;
        characrterSwitch.onRemoveNewDataPerson -= RemoveDataPerson;
    }
}
