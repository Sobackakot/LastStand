 
using UnityEngine;

public class SwitchActiveUI : MonoBehaviour
{
    [SerializeField] private GameObject InventoryPerson;

    private InputControlPerson inputPerson;

    private void Awake()
    {
        inputPerson = GetComponent<InputControlPerson>();
    }

    private void OnEnable()
    {
        inputPerson.onActiveInventory += ActiveInventory;
    }
    private void OnDisable()
    {
        inputPerson.onActiveInventory -= ActiveInventory;
    }
    private void ActiveInventory(bool isSwitchActiv)
    {
        if (isSwitchActiv)
        {
            InventoryPerson.SetActive(true);
        }
        else
        {
            InventoryPerson.SetActive(false);
        }
    }
}
