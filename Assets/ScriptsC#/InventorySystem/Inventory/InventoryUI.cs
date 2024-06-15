

using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private InventoryController inventory; 
    private List<ItemInSlot> slots = new List<ItemInSlot>();

    private void Awake()
    { 
        slots.AddRange(GetComponentsInChildren<ItemInSlot>(false));
    } 
    private void OnEnable()
    {
        inventory = InventoryController.Instance;
        inventory.onUpdateInventorySlots += UpdateInventorySlots;
    }
    private void OnDisable()
    {
        inventory.onUpdateInventorySlots -= UpdateInventorySlots;
    }
    private void UpdateInventorySlots() //coll from InventoryController
    {
        List<ItemScrObj> items = inventory.GetCurrentInventory();
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < items.Count)
            {
                slots[i].AddItemInSlot(items[i]); 
            }
            if(items[i] == null)
            {
                slots[i].CleareInSlot();
            }
        }
    } 
}
