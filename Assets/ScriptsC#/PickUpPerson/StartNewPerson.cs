
using System;
using UnityEngine;

public class StartNewPerson : MonoBehaviour
{
    [SerializeField] private PickUpPerson pick;
    private void Awake()
    {
        pick.isActive = true;
    }
}
