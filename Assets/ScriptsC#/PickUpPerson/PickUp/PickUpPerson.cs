
using UnityEngine; 
using UnityEngine.EventSystems;

public class PickUpPerson : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PersonDataScript personData; // static data person
    [SerializeField] private PersonDataManager dataManager;
    private bool isInitialized = false;
    public bool isActive = false;
    [HideInInspector] public string id; 

    private void OnEnable()
    {
        transform.position = dataManager.LoadPosition(personData);
    }
    private void OnDisable()
    {
        dataManager.SavePoisition(personData, transform);
    } 
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
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
}
