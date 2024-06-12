

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
    private void Start()
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
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventory.itemsArray.Length)
            {
                slots[i].AddItemInSlot(inventory.itemsArray[i]); 
            }
            if(inventory.itemsArray[i] == null)
            {
                slots[i].CleareInSlot();
            }
        }
    } 
}
