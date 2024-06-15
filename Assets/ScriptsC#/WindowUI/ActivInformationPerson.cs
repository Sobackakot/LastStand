
using UnityEngine;

public class ActivInformationPerson : MonoBehaviour
{
    [SerializeField] private GameObject InventoryPerson; 
    private InputControlPerson inputPerson;
    private InventoryController inventory;
     
    private void Awake()
    {
        inputPerson = GetComponent<InputControlPerson>();
    }
    private void Start()
    {
        inventory = InventoryController.Instance;
    }

    private void OnEnable()
    {
        inputPerson.onActiveInventory += ActiveInventory;
    }
    private void OnDisable()
    {
        inputPerson.onActiveInventory -= ActiveInventory;
    }
    private void ActiveInventory(bool isSwitchActiv) //coll from InputControlPerson
    {
        if (isSwitchActiv)
        {
            InventoryPerson.SetActive(true);
            inventory.UpdateInventory();
        }
        else
        {
            InventoryPerson.SetActive(false);
        }
    }
}
