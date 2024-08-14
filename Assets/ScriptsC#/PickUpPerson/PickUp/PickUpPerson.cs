 
using UnityEngine; 
using UnityEngine.EventSystems;
using Zenject;

public class PickUpPerson : MonoBehaviour, IPointerClickHandler
{
    [field:SerializeField] public PersonDataScript personData {  get; set; }   
    private CharacterSwitchSystem characrterSwitch;

    public Transform pointLookTarget { get; private set; } // use for class CameraLookTarget
     
    private bool isInitialized = false;// needed to check the first initialization of data

    public bool isActive { get; private set; } // needed to check the asset or deactivate components
    public string id { get; private set; }

    [Inject]
    private void Container(CharacterSwitchSystem characrterSwitch)
    {
        this.characrterSwitch = characrterSwitch;
    }
    private void Start()
    {
        pointLookTarget = transform.GetChild(0).GetComponent<Transform>(); 
        if (isActive)
            PickPerson();
    }
    public void OnPointerClick(PointerEventData eventData)
    {   
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            characrterSwitch?.CharacterPick(id);  //activating a character to control it
        }
        else
        {
            PickPerson(); //add a character to a squad
        }
    } 
    private void PickPerson() //pick on a new character
    {
        if (!isInitialized)
        {
            isInitialized = true;
             
            personData.data.SetNewPersonId();
            characrterSwitch?.AddPersonList(this, personData);//adds a new character to my squad list
            id = personData.data.ID; //set a unique id for a new character
        }
    } 
    public bool PersonActivationSwitch(bool _isActive) //coll from class CharacterSwitchSystem 
    {
        return isActive = _isActive; //person component activation switch
    }
}
 