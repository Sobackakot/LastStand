
using System;
using System.Collections.Generic;
using UnityEngine; 

public class CharacterSwitchingSystem : MonoBehaviour
{
    public static CharacterSwitchingSystem Instance; 
     
    [Header("List person UI and current amoutn PickUpPerson")]
    [SerializeField] private List<PickUpPersonUI> personsUI = new List<PickUpPersonUI>(30);
    [SerializeField] private List<PickUpPerson> personsObj = new List<PickUpPerson>(30);

    private Dictionary<GameObject, InputControlPerson> inputControlCache = new Dictionary<GameObject, InputControlPerson>(); //components
    private Dictionary<GameObject, PersonMoveControl> moveControlCache = new Dictionary<GameObject, PersonMoveControl>();//components

    public event Action<bool, PickUpPerson> onResetFocusCamera; // This Event for calss CameraLookTarget   
    public event Action<PersonData> onAddNewDataPerson; //This Event for PersonDataManager  
    public event Action onSaveDataPerson; // This Event for PersonDataManager
    public event Action onLoadDataPerson;// This Event for PersonDataManager
    public event Action<Transform> onSetNewTargetFolowCamera; //Tith Event for FollowCamera

    private void OnEnable()
    {
        onLoadDataPerson?.Invoke();
    }
    private void OnDisable()
    {
        onSaveDataPerson?.Invoke();
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
    public void AddPersonList(PickUpPerson person) // Add new person my group for PickUpPerson
    {
        personsObj.Add(person); 
        CacheComponents(person.gameObject); 
        if (inputControlCache.ContainsKey(person.gameObject)) //if there is such an object in the list, then turn off the components in advance
            inputControlCache[person.gameObject].OnDisableComponent(); 
        if (moveControlCache.ContainsKey(person.gameObject))
            moveControlCache[person.gameObject].OnDisableComponent();
    }
    public void RemovePersonList(PickUpPerson person) // Remove new person my group ...
    {
        personsObj.Remove(person);
        // add Action RemovePersonData for list PersonsDataList...
    }
    public void SetDataPerson(PersonDataScript dataScript) // set new first data for PickUpPerson
    {   
        dataScript.data.SetNewPersonId(); // set new id person for PersonData
        onAddNewDataPerson?.Invoke(dataScript.data);// Add new data person for PersonsDataList ..... 
        foreach (var uiGroup in personsUI)
        {
            if (!uiGroup.HasData()) //  check is first set  data for person 
            {
                ActivePersonUI(uiGroup);
                uiGroup.SetDataPersonUI(dataScript);
                break; // Stop after finding the first empty slot
            }
        } 
    }
    public void SetFocusCamera(in string id) //set focus camera for PickUpPersonUI 
    {
       
        foreach (PickUpPerson pick in personsObj)
        {
            if (pick.id == id)
            {
                pick.isActive = true;
                onResetFocusCamera?.Invoke(false, pick);// ResetLookPoint camera focus on selected person
                onSetNewTargetFolowCamera?.Invoke(pick.transform);// Set new target follow camera
                inputControlCache[pick.gameObject].OnEnableComponent(); // next pick person Activating components
                moveControlCache[pick.gameObject].OnEnableComponent();
                continue;
            }
            if (pick.isActive)
            {
                pick.isActive = false;
                inputControlCache[pick.gameObject].OnDisableComponent();// Deactive  current person components
                moveControlCache[pick.gameObject].OnDisableComponent(); 
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
    private void CacheComponents(GameObject obj) //Cached new person components
    {
        if (!inputControlCache.ContainsKey(obj))
        {
            var inputControl = obj.GetComponent<InputControlPerson>(); //Cached InputControlPerson Component
            inputControlCache[obj] = inputControl; 
        }
        if (!moveControlCache.ContainsKey(obj))
        {
            var moveControl = obj.GetComponent<PersonMoveControl>(); // Cached PersonMoveControl component
            moveControlCache[obj] = moveControl; 
        }
    }
}
