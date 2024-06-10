
using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    private InventoryController inventorySystem;
    public static EquipmentController Instance;
    private Equipment[] equipmentCurrent;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        int indexSlot = System.Enum.GetNames(typeof(EquipItem)).Length;
        equipmentCurrent = new Equipment[indexSlot];
        inventorySystem = InventoryController.Instance;
    }
    public void EquipItem(Equipment newItem)
    {
        int currentIndex = (int)newItem.IndexOfSlot;
        Equipment oldItem = null;
        if (equipmentCurrent[currentIndex] != null)
        {
            oldItem = equipmentCurrent[currentIndex];
            inventorySystem.AddItemToInventory(oldItem);
        }
        equipmentCurrent[currentIndex] = newItem;
    }
    public void UnEquipItem(int currentIndex)
    { 
        if (equipmentCurrent[currentIndex] != null)
        {
            Equipment oldItem = equipmentCurrent[currentIndex];
            inventorySystem.AddItemToInventory(oldItem);
            equipmentCurrent[currentIndex] = null;
        }
    }
    private void UnEquipItemsAll()
    {
       for(int i = 0; i< equipmentCurrent.Length; i++)
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
