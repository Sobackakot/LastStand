
using System.Collections.Generic; 

public class EquipmentPerson 
{
    public readonly List<Equipment> equipmentItem;
     
    public EquipmentPerson()
    {   
        int indexSlot = System.Enum.GetNames(typeof(EquipItem)).Length; //get the number of slots for equipment items
        equipmentItem = new List<Equipment>(indexSlot);
        for(int i =0; i< indexSlot; i++)
        {
            equipmentItem.Add(null); //initialize item equipment slots
        }
    }
    public void EquipItemOnPerson(Equipment newItem) 
    {
        int currentIndex = (int)newItem.IndexOfSlot; // convert from Equipment Slot to index
        Equipment oldItem = null;
        if (equipmentItem[currentIndex] != null) //if such an item is already equipped
        {
            oldItem = equipmentItem[currentIndex]; //return the item back to inventory
            InventoryController.Instance.AddItemToInventory(oldItem);
        }
        equipmentItem[currentIndex] = newItem;//equip pick item  from inventory cell 
    }
    public void UnEquipItemFromPerson(int currentIndex)
    {
        if (equipmentItem[currentIndex] != null)//if such an item is already equipped
        {
            Equipment oldItem = equipmentItem[currentIndex];//return the item back to inventory
            InventoryController.Instance.AddItemToInventory(oldItem);
            equipmentItem[currentIndex] = null;//reset an item's equipment slot
        }
    }
}
