
using System.Collections.Generic; 

public class EquipmentPerson 
{
    private InventoryController inventory;
    public List<Equipment> equipmentItem;
     
    public EquipmentPerson()
    {
        int indexSlot = System.Enum.GetNames(typeof(EquipItem)).Length;
        equipmentItem = new List<Equipment>(indexSlot);
        for(int i =0; i< indexSlot; i++)
        {
            equipmentItem.Add(null);
        }
        inventory = InventoryController.Instance;
    }
    public void EquipItemOnPerson(Equipment newItem)
    {
        int currentIndex = (int)newItem.IndexOfSlot;
        Equipment oldItem = null;
        if (equipmentItem[currentIndex] != null)
        {
            oldItem = equipmentItem[currentIndex];
            InventoryController.Instance.AddItemToInventory(oldItem);
            //inventory.AddItemToInventory(oldItem);
        }
        equipmentItem[currentIndex] = newItem;
    }
    public void UnEquipItemFromPerson(int currentIndex)
    {
        if (equipmentItem[currentIndex] != null)
        {
            Equipment oldItem = equipmentItem[currentIndex];
            InventoryController.Instance.AddItemToInventory(oldItem);
            //inventory.AddItemToInventory(oldItem);
            equipmentItem[currentIndex] = null;
        }
    }
}
