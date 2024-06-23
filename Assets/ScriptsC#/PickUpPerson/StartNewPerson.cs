
using UnityEngine;

public class StartNewPerson : MonoBehaviour
{
    private PickUpPerson pick;  
    private void Awake() //activates the character on whom this script with the PickUpPerson component will hang
    {   
        pick = GetComponent<PickUpPerson>();
        pick.PersonActivationSwitch(true); // frnbd
    }
}
