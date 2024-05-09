using System.IO;
using UnityEngine;

public class PersonDataManager : MonoBehaviour
{    
    private PersonsDataList  dataList;  

    private void Start()
    {
        dataList = new PersonsDataList();
    }
    private void OnEnable()
    {
        CharacterSwitchingSystem.Instance.onAddNewDataPerson += AddDataPerson;
        CharacterSwitchingSystem.Instance.onSaveData += SaveData;
        CharacterSwitchingSystem.Instance.onLoadData += LoadData;
    }
    private void OnDisable()
    {
        CharacterSwitchingSystem.Instance.onAddNewDataPerson -= AddDataPerson;
        CharacterSwitchingSystem.Instance.onSaveData -= SaveData;
        CharacterSwitchingSystem.Instance.onLoadData -= LoadData;
    }
    public void AddDataPerson(PersonData data)
    {
        if (dataList.dataPersons.Contains(data)) return;
        dataList.dataPersons.Add(data);
        Debug.Log("Add new PersonData to PersonManager");
    }
    public void RemoveDataPerson(PersonData data)
    {
        if (!dataList.dataPersons.Contains(data)) return;
        dataList.dataPersons.Remove(data);
        Debug.Log("Remove PersonData from PersonManager");
    }
    public async void SaveData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "Data.txt"); 
        await SaveDataSystem.SaveDataAsync(dataList, filePath);
        Debug.Log("Manager call save");
    }
    public async void LoadData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "Data.txt");
        dataList = await SaveDataSystem.LoadDataAsync(filePath);
        Debug.Log("Manager call load");
    }
}
