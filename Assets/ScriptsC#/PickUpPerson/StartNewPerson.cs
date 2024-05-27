
using System;
using UnityEngine;

public class StartNewPerson : MonoBehaviour
{
    private PickUpPerson pick;  
    private void Awake()
    {   
        pick = GetComponent<PickUpPerson>();
        pick.isActive = true;
    }
}
