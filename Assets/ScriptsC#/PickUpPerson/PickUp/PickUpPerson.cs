
using UnityEngine; 
using UnityEngine.EventSystems;

public class PickUpPerson : MonoBehaviour, IPointerClickHandler
{ 
    public PersonDataScript personData;
    public Transform pointLookTarget;

    private CharacterSwitchSystem characterSystem;

    private bool isInitialized = false;// needed to check the first initialization of data

    [HideInInspector] public bool isActive = false; // needed to check the asset or deactivate components
    [HideInInspector] public string id { get; private set; }
     
    private void Start()
    {
        characterSystem = CharacterSwitchSystem.Instance;
        if (isActive)
            PickPerson();
    }
    public void OnPointerClick(PointerEventData eventData)
    {   
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            characterSystem.CharacterPick(id);  //activating a character to control it
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
            characterSystem.AddPersonList(this, personData);//adds a new character to my squad list
            id = personData.data.ID;
        }
    } 
}
