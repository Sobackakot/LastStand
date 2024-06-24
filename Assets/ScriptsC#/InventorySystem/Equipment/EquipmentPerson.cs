
using System.Collections.Generic; 

public class EquipmentPerson 
{
    public readonly List<EquipmentScrObj> equipmentItem;
     
    public EquipmentPerson()
    {   
        int indexSlot = System.Enum.GetNames(typeof(EquipItem)).Length; //get the number of slots for equipment items
        equipmentItem = new List<EquipmentScrObj>(indexSlot);
        for(int i =0; i< indexSlot; i++)
        {
            equipmentItem.Add(null); //initialize item equipment slots
        }
    }
    public void EquipItemOnPerson(out int slotIndex, EquipmentScrObj newItem) 
    {
        int currentIndex = (int)newItem.IndexOfSlot; // convert from EquipmentScrObj Slot to index 
        EquipmentScrObj oldItem = null;
        if (equipmentItem[currentIndex] != null) //if such an item is already equipped
        {
            oldItem = equipmentItem[currentIndex]; //return the item back to inventory
            InventoryController.Instance.AddItemToInventory(oldItem);
        }
        slotIndex = currentIndex;
        equipmentItem[currentIndex] = newItem;//equip pick item  from inventory cell 
    }
    public void UnEquipItemFromPerson(int currentIndex)
    {
        if (equipmentItem[currentIndex] != null)//if such an item is already equipped
        {
            EquipmentScrObj oldItem = equipmentItem[currentIndex];//return the item back to inventory
            InventoryController.Instance.AddItemToInventory(oldItem);
            equipmentItem[currentIndex] = null;//reset an item's equipment slot 
        }
    }
    public List<EquipmentScrObj> GetEquipmentItems()
    {
        return equipmentItem;
    }
}
