 
using System;
using System.Collections.Generic; 
using UnityEngine; 

public class CharacterSwitchingSystem : MonoBehaviour
{
    public static CharacterSwitchingSystem Instance; 
     
    [Header("List person UI - You need to fill the list with objects from the UI slots for characters!!!")]
    [SerializeField] private List<PickUpPersonUI> personsUISquad = new List<PickUpPersonUI>(30);
    
    private List<PickUpPerson> personsSquad = new List<PickUpPerson>(30);
    public IEnumerable<PickUpPerson> PersonsSquad => personsSquad;

    private Dictionary<PickUpPerson, InputControlPerson> inputComponents = new Dictionary<PickUpPerson, InputControlPerson>(); //components
    private Dictionary<PickUpPerson, PersonMoveControl> moveComponents = new Dictionary<PickUpPerson, PersonMoveControl>();//components
    public IEnumerable<KeyValuePair<PickUpPerson, InputControlPerson>> InputComponents => inputComponents;
    public IEnumerable<KeyValuePair<PickUpPerson, PersonMoveControl>> MoveComponents => moveComponents;


    public event Action<bool, PickUpPerson> onResetFocusCamera; // This Event for calss CameraLookTarget   
    public event Action<PersonData> onAddNewDataPerson; //This Event for PersonDataManager  
    public event Action<Transform> onSetNewTargetFolowCamera; //Tith Event for FollowCamera 
    
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
        AddComponentsByDictionary(person); //Cached new person components
        DisableComponentsPerson(person); //if there is such an object in the list, then turn off the components in advance 
    }
    public void RemovePersonList(PickUpPerson person) // Remove new person my group ...
    {
        RemoveComponentsByDictionary(person);
        personsSquad.Remove(person); 
        
    }
    public void SetDataPerson(PersonDataScript dataScript) // set new first data for PickUpPerson
    {   
        dataScript.data.SetNewPersonId(); // set new id person for PersonData
        onAddNewDataPerson?.Invoke(dataScript.data);// Add new data person for PersonsDataList from PersonDataManager
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
    public void ResetDataPerson(PersonDataScript dataScript)  //deletes all information in the ui and in the data
    {
        // add Action RemoveDataPerson for list PersonsDataList from PersonDataManager
        // ResetDataPersonUI
        // add Deactive PersonUI
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
        onResetFocusCamera?.Invoke(false, pick);// ResetLookPoint follow camera focus on selected for pick up Person
        onSetNewTargetFolowCamera?.Invoke(pick.transform);// Set new target follow camera, clamping circle radius
    } 
    private void ActivePersonUI(PickUpPersonUI uiSlot) //Active new person my ui slot group
    {
        uiSlot.gameObject.SetActive(true);
    }
    private void DeActivePersonUI(PickUpPersonUI uiSlot) //Deactive new person my ui slot group ...
    {
        uiSlot.gameObject.SetActive(false);
    }
    private void AddComponentsByDictionary(PickUpPerson person) //Cached new person components
    {
        if (!inputComponents.ContainsKey(person))
        {
            var inputControl = person.GetComponent<InputControlPerson>(); //Cached InputControlPerson components by Dictionary
            inputComponents[person] = inputControl; 
        }
        if (!moveComponents.ContainsKey(person))
        {
            var moveControl = person.GetComponent<PersonMoveControl>(); // Cached PersonMoveControl components by Dictionary
            moveComponents[person] = moveControl;    
        }
    }
    private void RemoveComponentsByDictionary(PickUpPerson person) // Remove components by Dictionary...
    {
        if (personsSquad.Contains(person))
        {
            inputComponents.Remove(person);
            moveComponents.Remove(person); 
        }      
    }
    public void EnableComponentsPerson(PickUpPerson pick) // call from SelectPersonSystem
    {
        pick.isActive = true;
        if (inputComponents.ContainsKey(pick))
            inputComponents[pick].OnEnableComponent(); // next pick person Activating components
        if (moveComponents.ContainsKey(pick))
            moveComponents[pick].OnEnableComponent();
    }
    public void DisableComponentsPerson(PickUpPerson pick) // call from SelectPersonSystem
    {
        pick.isActive = false;
        if (inputComponents.ContainsKey(pick))
            inputComponents[pick].OnDisableComponent();// Deactive  current person components
        if (moveComponents.ContainsKey(pick))
            moveComponents[pick].OnDisableComponent();
    }
}
