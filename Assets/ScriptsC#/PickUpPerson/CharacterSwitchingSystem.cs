
using System;
using System.Collections.Generic; 
using UnityEngine; 

public class CharacterSwitchingSystem : MonoBehaviour
{
    public static CharacterSwitchingSystem Instance; 
     
    [Header("List person UI and current amoutn PickUpPerson")]
    [SerializeField] private List<PickUpPersonUI> personsUI = new List<PickUpPersonUI>(30);
    [SerializeField] private List<PickUpPerson> personsObj = new List<PickUpPerson>(30);
    [SerializeField] private List<GameObject> gameObjectPersonComponents = new List<GameObject>(30);

    public event Action<bool, PickUpPerson> onResetFocusCamera; // This Event for calss CameraLookTarget   
    public event Action<PersonData> onAddNewDataPerson; //This Event for PersonDataManager
    public event Action onSaveData;
    public event Action onLoadData;
    private void OnDisable()
    {
        onSaveData?.Invoke();
    }
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        onLoadData?.Invoke();
    }
    public void AddPersonList(PickUpPerson person,GameObject gameObjectPerson) // Add new person my group
    {
        personsObj.Add(person);
        gameObjectPersonComponents.Add(gameObjectPerson);
        gameObjectPerson.GetComponent<InputControlPerson>().OnDisableComponent();
        gameObjectPerson.GetComponent<PersonMoveControl>().OnDisableComponent();  
    }
    public void RemovePersonList(PickUpPerson person, GameObject gameObjectPerson) // Remove new person my group ...
    {
        personsObj.Remove(person);
        gameObjectPersonComponents.Remove(gameObjectPerson); 
        // add Action RemovePersonData for list PersonsDataList...
    }
    public void SetDataPerson(PersonDataScript dataScript) // set new first data person 
    {
        dataScript.data.GetCurrenPersonId(); // set new id person for PersonData
        onAddNewDataPerson?.Invoke(dataScript.data);// Add new data person for PersonsDataList .....
        foreach (var uiGroup in personsUI)
        {
            if (!uiGroup.HasData()) //  check is first set  data for person 
            {
                ActivePersonUI(uiGroup);
                uiGroup.SetDataPersonUI();
                break; // Stop after finding the first empty slot
            }
        } 
    }
    public void SetFocusCamera(in string id) //set focus camera pickup person
    {
        for(int i = 0; i < personsObj.Count; i++)
        {   
            if (personsObj[i].id ==id)
            {
                personsObj[i].isActive = true;
                onResetFocusCamera?.Invoke(false, personsObj[i]); // ResetLookPoint 
                gameObjectPersonComponents[i].GetComponent<InputControlPerson>().OnEnableComponent(); // next pick person Activating components
                gameObjectPersonComponents[i].GetComponent<PersonMoveControl>().OnEnableComponent(); 
                continue;
            }
            if (personsObj[i].isActive)
            {
                personsObj[i].isActive = false; 
                gameObjectPersonComponents[i].GetComponent<InputControlPerson>().OnDisableComponent(); // Deactive  current person components
                gameObjectPersonComponents[i].GetComponent<PersonMoveControl>().OnDisableComponent(); 
            }
        }
    }
    private void ActivePersonUI(PickUpPersonUI uiSlot) //Active new person my ui slot group
    {
        uiSlot.gameObject.SetActive(true);
    }
    private void DeActivePersonUI(PickUpPersonUI uiSlot) //Deactive new person my ui slot group ...
    {
        uiSlot.gameObject.SetActive(false);
    }
}
