
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
        inventorySystem.onUpdateEquipmentSlot += UpdateEquipmentSlot;
    }
    private void OnEnable()
    {
        //inventorySystem = InventoryController.Instance;
        //inventorySystem.onUpdateEquipmentSlot += UpdateEquipmentSlot; 
    }
    private void OnDisable()
    {
        inventorySystem.onUpdateEquipmentSlot -= UpdateEquipmentSlot;
    }

    private void UpdateEquipmentSlot(PersonDataScript person)
    {
        equipmentPerson = person.equipmentPerson;
    }

    public void EquipItem(Equipment newItem)
    {   
        equipmentPerson.EquipItemOnPerson(newItem);
    }
    public void UnEquipItem(int currentIndex)
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            UnEquipItemsAll();
        }
    }
}
