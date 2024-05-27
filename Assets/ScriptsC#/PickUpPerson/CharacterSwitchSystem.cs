 
using System;
using System.Collections.Generic; 
using UnityEngine; 

public class CharacterSwitchSystem : MonoBehaviour
{
    public static CharacterSwitchSystem Instance; 
     

    [HideInInspector] public readonly List<PickUpPerson> PersonsSquad = new List<PickUpPerson>(30); //List persons squad

    [HideInInspector] public readonly Dictionary<PickUpPerson, InputControlPerson> InputComponents = new Dictionary<PickUpPerson, InputControlPerson>(); //components
    [HideInInspector] public readonly Dictionary<PickUpPerson, PersonMoveControl> MoveComponents = new Dictionary<PickUpPerson, PersonMoveControl>();//components


    private List<PickUpPersonUI> personsUISquad = new List<PickUpPersonUI>(30); //List persons UI slots 
      
    public event Action<bool, PickUpPerson> onResetFocusCamera; // This Event for calss CameraLookTarget   
    public event Action<PersonData> onAddNewDataPerson; //This Event for PersonDataManager
    public event Action<PersonData> onRemoveNewDataPerson; //This Event for PersonDataManager  
    public event Action<Transform> onSetNewTargetFolowCamera; //Tith Event for FollowCamera 
    public event Action onUpdateCellSizeGrid; //this event for GridLayoutGroupPerson
    
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        // Automatically fill the personsUISquad list with child PickUpPersonUI components
        personsUISquad.AddRange(GetComponentsInChildren<PickUpPersonUI>(true));
    }
    public void RemovePerson(string id) // call from PickUpPersonUI
    {   
        PickUpPerson personToRemove = null;
        foreach(PickUpPerson pick in PersonsSquad)
        {
            if (pick.id == id)
            {
               personToRemove = pick;   
               break;
            }
        }
        if(personToRemove != null)
            RemovePersonList(personToRemove, personToRemove.personData);
    }
    public void AddPersonList(PickUpPerson person, PersonDataScript dataScript) // Add new person my group for PickUpPerson
    {
        SetDataPerson(dataScript);
        PersonsSquad.Add(person); 
        AddComponentsByDictionary(person); //Cached new person components
        DisableComponentsPerson(person); //if there is such an object in the list, then turn off the components in advance 
    }
    private void RemovePersonList(PickUpPerson person, PersonDataScript dataScript) // Remove new person my group ...
    {
        ResetDataPerson(dataScript);
        DisableComponentsPerson(person);
        RemoveComponentsByDictionary(person);
        PersonsSquad.Remove(person);  
    }
    private void SetDataPerson(PersonDataScript dataScript) // set new first data for PickUpPerson
    {   
        dataScript.data.SetNewPersonId(); // set new id person for PersonData
        onAddNewDataPerson?.Invoke(dataScript.data);// Add new data person for PersonsDataList from PersonDataManager
        foreach (var uiGroup in personsUISquad)
        {
            if (!uiGroup.HasData()) //  check is first set  data for person. !!!need to add cells to the PickUpPersonUI list!!!
            {
                ActivePersonUI(uiGroup);
                uiGroup.SetDataPersonUI(dataScript);
                break; // Stop after finding the first empty slot
            }
        } 
    }
    private void ResetDataPerson(PersonDataScript dataScript)  //deletes all information in the ui and in the data
    {   
        string ID = dataScript.data.ID;
       
        onRemoveNewDataPerson?.Invoke(dataScript.data);// Remove data person for PersonsDataList from PersonDataManager 
        foreach (var uiGroup in personsUISquad)
        {
            if (uiGroup.HasData() && uiGroup.id == ID) //  check is first set  data for person 
            {
                DeactivePersonUI(uiGroup); 
                break; // Stop after finding the first empty slot
            }
        }
    }

    public void CharacterPick(string id) //click on the character to enable all components
    {
        foreach(PickUpPerson pick in PersonsSquad)
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
    public void �haracterSwitch(string id) //set focus camera for PickUpPersonUI 
    { 
        foreach (PickUpPerson pick in PersonsSquad)
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
        onUpdateCellSizeGrid?.Invoke(); //sets the size of character cells in the UI grid
    }
    public void DeactivePersonUI(PickUpPersonUI uiSlot) //Deactive new person my ui slot group 
    {
        uiSlot.gameObject.SetActive(false);
        onUpdateCellSizeGrid?.Invoke();//sets the size of character cells in the UI grid
    }
    private void AddComponentsByDictionary(PickUpPerson person) //Cached new person components
    {
        if (!InputComponents.ContainsKey(person))
        {
            var inputControl = person.GetComponent<InputControlPerson>(); //Cached InputControlPerson components by Dictionary
            InputComponents[person] = inputControl; 
        }
        if (!MoveComponents.ContainsKey(person))
        {
            var moveControl = person.GetComponent<PersonMoveControl>(); // Cached PersonMoveControl components by Dictionary
            MoveComponents[person] = moveControl;    
        }
    }
    private void RemoveComponentsByDictionary(PickUpPerson person) // Remove components by Dictionary
    {
        if (PersonsSquad.Contains(person))
        {
            InputComponents.Remove(person);
            MoveComponents.Remove(person); 
        }      
    }
    public void EnableComponentsPerson(PickUpPerson pick) // call from SelectPersonSystem
    {
        pick.isActive = true;
        if (InputComponents.ContainsKey(pick))
            InputComponents[pick].OnEnableComponent(); // next pick person Activating components
        if (MoveComponents.ContainsKey(pick))
            MoveComponents[pick].OnEnableComponent();
    }
    public void DisableComponentsPerson(PickUpPerson pick) // call from SelectPersonSystem
    {
        pick.isActive = false;
        if (InputComponents.ContainsKey(pick))
            InputComponents[pick].OnDisableComponent();// Deactive  current person components
        if (MoveComponents.ContainsKey(pick))
            MoveComponents[pick].OnDisableComponent();
    }
}
