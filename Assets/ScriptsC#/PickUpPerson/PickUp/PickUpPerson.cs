
using UnityEngine; 
using UnityEngine.EventSystems;

public class PickUpPerson : MonoBehaviour, IPointerClickHandler
{ 
    public PersonDataScript personData;
    public Transform pointLookTarget;

    private bool isInitialized = false;// needed to check the first initialization of data
    public bool isActive = false; // needed to check the asset or deactivate components
    [HideInInspector] public string id;

    private void Start()
    {  
        if(isActive)
            PickPerson();
    }
    public void OnPointerClick(PointerEventData eventData)
    {   
        if(eventData.button == PointerEventData.InputButton.Left)
        { 
            CharacterSwitchSystem.Instance?.CharacterPick(in id);  //activating a character to control it
        }
        else
        {
            PickPerson(); //add a character to a squad
        }
    } 
    private void PickPerson()
    {
        if (!isInitialized)
        {
            isInitialized = true;
            CharacterSwitchSystem.Instance?.AddPersonList(this, personData);//adds a new character to my squad list
            id = personData.data.ID;
        }
    } 
}
