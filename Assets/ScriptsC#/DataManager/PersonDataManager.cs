using System.IO; 
using UnityEngine;

public class PersonDataManager : MonoBehaviour
{    
    private PersonsDataList  dataList; 
    private void Start()
    {
        dataList = new PersonsDataList();
        CharacterSwitchingSystem.Instance.onAddNewDataPerson += AddDataPerson;
        CharacterSwitchingSystem.Instance.onSaveDataPerson += SaveData;
        CharacterSwitchingSystem.Instance.onLoadDataPerson += LoadData;
    } 
    private void OnDisable()
    {
        CharacterSwitchingSystem.Instance.onAddNewDataPerson -= AddDataPerson;
        CharacterSwitchingSystem.Instance.onSaveDataPerson -= SaveData;
        CharacterSwitchingSystem.Instance.onLoadDataPerson -= LoadData;
    }
    public void AddDataPerson(PersonData data) // add new person for PersonsDataListst
    {
        if (dataList.dataPersons.Contains(data)) return;
        dataList.dataPersons.Add(data); 
        Debug.Log("Add new PersonData to PersonManager");
    }
    public void RemoveDataPerson(PersonData data) //remove person from PersonsDataListst
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
   
    public void SavePoisition(PersonDataScript dataScript,Transform person)
    {
        dataScript.data.SavePositionPerson(person);
    }
    public Vector3 LoadPosition(PersonDataScript dataScripts)
    { 
        Vector3 newPosition = dataScripts.data.LoadPositionPerson();
        return newPosition;
    }
}
