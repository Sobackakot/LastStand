using System;
using System.IO; 
using UnityEngine;
using Zenject;

public class PersonDataManager : IInitializable, IDisposable
{    
    private PersonsDataList  dataList;
    private CharacterSwitchSystem characrterSwitch;
     
    private PersonDataManager(CharacterSwitchSystem characrterSwitch)
    { 
        this.characrterSwitch = characrterSwitch;
    }
    public void Initialize()
    {
        dataList = new PersonsDataList();
        characrterSwitch.onAddNewDataPerson += AddDataPerson;
        characrterSwitch.onRemoveNewDataPerson += RemoveDataPerson;
    }

    public void Dispose()
    {
        characrterSwitch.onAddNewDataPerson -= AddDataPerson;
        characrterSwitch.onRemoveNewDataPerson -= RemoveDataPerson;
    }
    
    private void AddDataPerson(PersonData data) // add new person for PersonsDataList from CharacterSwitchSystem
    {
        if (dataList.dataPersons.Contains(data)) return;
        dataList.dataPersons.Add(data);
    }
    private void RemoveDataPerson(PersonData data) //remove person from PersonsDataList from CharacterSwitchSystem...
    {
        if (!dataList.dataPersons.Contains(data)) return;
        dataList.dataPersons.Remove(data);
    }
    public async void SaveData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "Data.txt");
        await SaveDataSystem.SaveDataAsync(dataList, filePath); 
    }
    public async void LoadData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "Data.txt");
        dataList = await SaveDataSystem.LoadDataAsync(filePath); 
    } 
}
