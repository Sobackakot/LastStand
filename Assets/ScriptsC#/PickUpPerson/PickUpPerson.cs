
using UnityEngine; 
using UnityEngine.EventSystems;

public class PickUpPerson : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PersonDataScript personData; 
    private bool isInitialized = false;
    public bool isActive = false;
    [HideInInspector]public string id;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!isInitialized)
            {   
                isInitialized = true;
                CharacterSwitchingSystem.Instance?.SetDataPerson(personData);
                CharacterSwitchingSystem.Instance?.AddPersonList(this,gameObject);
                id = personData.Id;
            } 
        }
    } 
}
