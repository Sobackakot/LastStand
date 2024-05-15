
using UnityEngine; 
using UnityEngine.EventSystems;

public class PickUpPerson : MonoBehaviour, IPointerClickHandler
{ 
    [SerializeField] private PersonDataScript personData;  

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
            CharacterSwitchingSystem.Instance?.CharacterPick(in id);  
        }
        else
        {
            PickPerson();
        }
    } 
    private void PickPerson()
    {
        if (!isInitialized)
        {
            isInitialized = true;
            CharacterSwitchingSystem.Instance?.SetDataPerson(personData); // set first data new person game 
            CharacterSwitchingSystem.Instance?.AddPersonList(this);
            id = personData.data.ID;
        }
    } 
}
