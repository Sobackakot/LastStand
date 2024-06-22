
using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    private InventoryController inventorySystem;
    public static EquipmentController Instance;
    private EquipmentPerson equipmentPerson;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        inventorySystem = InventoryController.Instance;
        inventorySystem.onUpdateEquipmentSlot += GetPersonByEquipment;
    }
  
    private void OnDisable()
    {
        inventorySystem.onUpdateEquipmentSlot -= GetPersonByEquipment;
    }

    private void GetPersonByEquipment(PersonDataScript person) //get a link to the current character. coll from class InvectoryController
    {
        equipmentPerson = person.equipmentPerson;
    }

    public void EquipItem(Equipment newItem) //coll from Equipment
    {   
        equipmentPerson.EquipItemOnPerson(newItem);
    }
    private void UnEquipItem(int currentIndex)
    {
        equipmentPerson.UnEquipItemFromPerson(currentIndex);
    }
    private void UnEquipItemsAll()
    {
       for(int i = 0; i< equipmentPerson.equipmentItem.Count; i++)
       {
            UnEquipItem(i);
       }
    }
    private void LateUpdate() //......
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            UnEquipItemsAll();
        }
    }
}
