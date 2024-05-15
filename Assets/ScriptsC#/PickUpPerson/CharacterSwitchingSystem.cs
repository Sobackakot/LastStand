 
using System;
using System.Collections.Generic; 
using UnityEngine; 

public class CharacterSwitchingSystem : MonoBehaviour
{
    public static CharacterSwitchingSystem Instance; 
     
    [Header("List person UI - You need to fill the list with objects from the UI slots for characters!!!")]
    [SerializeField] private List<PickUpPersonUI> personsUISquad = new List<PickUpPersonUI>(30);
    
    private List<PickUpPerson> personsSquad = new List<PickUpPerson>(30);

    private Dictionary<PickUpPerson, InputControlPerson> inputControlComponents = new Dictionary<PickUpPerson, InputControlPerson>(); //components

    private Dictionary<PickUpPerson, PersonMoveControl> moveControlComponents = new Dictionary<PickUpPerson, PersonMoveControl>();//components

    public event Action<bool, PickUpPerson> onResetFocusCamera; // This Event for calss CameraLookTarget   
    public event Action<PersonData> onAddNewDataPerson; //This Event for PersonDataManager  
    public event Action<Transform> onSetNewTargetFolowCamera; //Tith Event for FollowCamera 
    public event Action<PickUpPerson> onUpdatePersonsBySelect;

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
        personsSquad.Add(person); 
        CacheComponents(person); //Cached new person components
        DisableComponentsPerson(person); //if there is such an object in the list, then turn off the components in advance 
        //onUpdatePersonsBySelect.Invoke(person);
    }
    public void RemovePersonList(PickUpPerson person) // Remove new person my group ...
    {
        personsSquad.Remove(person);
        //onUpdatePersonsBySelect.Invoke(person);
        // add Action RemovePersonData for list PersonsDataList...
    }
    public void SetDataPerson(PersonDataScript dataScript) // set new first data for PickUpPerson
    {   
        dataScript.data.SetNewPersonId(); // set new id person for PersonData
        onAddNewDataPerson?.Invoke(dataScript.data);// Add new data person for PersonsDataList ..... 
        foreach (var uiGroup in personsUISquad)
        {
            if (!uiGroup.HasData()) //  check is first set  data for person 
            {
                ActivePersonUI(uiGroup);
                uiGroup.SetDataPersonUI(dataScript);
                break; // Stop after finding the first empty slot
            }
        } 
    }
    public void CharacterPick(in string id) //click on the character to enable all components
    {
        foreach(PickUpPerson pick in personsSquad)
        {
            if (pick.id == id)
            {
                EnableComponentsPerson(pick);
                continue;
            }
            if (pick.isActive)
            {
                DisableComponentsPerson(pick);
            }
        }
    }
    public void ÑharacterSwitch(in string id) //set focus camera for PickUpPersonUI 
    { 
        foreach (PickUpPerson pick in personsSquad)
        {
            if (pick.id == id)
            {
                SetFocusCamera(pick);
                EnableComponentsPerson(pick);
                continue;
            }
            if (pick.isActive)
            {
                DisableComponentsPerson(pick);
            }
        }
    }
    private void SetFocusCamera(PickUpPerson pick)
    {
        onResetFocusCamera?.Invoke(false, pick);// ResetLookPoint camera focus on selected person
        onSetNewTargetFolowCamera?.Invoke(pick.transform);// Set new target follow camera
    } 
    private void ActivePersonUI(PickUpPersonUI uiSlot) //Active new person my ui slot group
    {
        uiSlot.gameObject.SetActive(true);
    }
    private void DeActivePersonUI(PickUpPersonUI uiSlot) //Deactive new person my ui slot group ...
    {
        uiSlot.gameObject.SetActive(false);
    }
    private void CacheComponents(PickUpPerson person) //Cached new person components
    {
        if (!inputControlComponents.ContainsKey(person))
        {
            var inputControl = person.GetComponent<InputControlPerson>(); //Cached InputControlPerson Component
            inputControlComponents[person] = inputControl; 
        }
        if (!moveControlComponents.ContainsKey(person))
        {
            var moveControl = person.GetComponent<PersonMoveControl>(); // Cached PersonMoveControl component
            moveControlComponents[person] = moveControl; 
        }
    }
    private void EnableComponentsPerson(PickUpPerson pick)
    {
        pick.isActive = true;
        inputControlComponents[pick].OnEnableComponent(); // next pick person Activating components
        moveControlComponents[pick].OnEnableComponent();
    }
    private void DisableComponentsPerson(PickUpPerson pick)
    {
        pick.isActive = false;
        if (inputControlComponents.ContainsKey(pick))
            inputControlComponents[pick].OnDisableComponent();// Deactive  current person components
        if (moveControlComponents.ContainsKey(pick))
            moveControlComponents[pick].OnDisableComponent();
    }
}
