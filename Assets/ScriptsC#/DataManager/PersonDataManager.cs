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
    }
    private void OnDisable()
    {
        CharacterSwitchingSystem.Instance.onAddNewDataPerson -= AddDataPerson;
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
}
