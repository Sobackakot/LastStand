 
using UnityEngine;

public class StartNewPerson : MonoBehaviour
{
    [SerializeField] private PersonDataScript personData;
    [SerializeField] private PickUpPerson pickUpPerson;
    private void Start()
    {
        pickUpPerson.id = personData.data.ID;
        pickUpPerson.SetInitialized(true);
        CharacterSwitchingSystem.Instance?.SetDataPerson(personData); // set first data new person game 
        CharacterSwitchingSystem.Instance?.AddPersonList(pickUpPerson);
    }  
}
