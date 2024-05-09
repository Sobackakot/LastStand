
using UnityEngine; 
using UnityEngine.EventSystems;

public class PickUpPerson : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PersonDataScript personData; // static data person
    private bool isInitialized = false;
    public bool isActive = false;
    [HideInInspector] public string id;
    private void OnEnable()
    {
        transform.position = personData.data.LoadPositionPerson(); 
    }
    private void OnDisable()
    {
        personData.data.SavePositionPerson(transform);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!isInitialized)
            {   
                isInitialized = true;
                CharacterSwitchingSystem.Instance?.SetDataPerson(personData); // set first data new person game
                CharacterSwitchingSystem.Instance?.AddPersonList(this,gameObject); //Add new gamObjects person in list  
                id = personData.data.GetCurrenPersonId(); 
            }
            Debug.Log(id);
        }
    } 
}
