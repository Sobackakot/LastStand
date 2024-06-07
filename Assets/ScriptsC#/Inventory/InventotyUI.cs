

using System.Collections.Generic;
using UnityEngine;

public class InventotyUI : MonoBehaviour
{
    private InventoryContoller inventory; 
    private List<ItemInSlot> slots = new List<ItemInSlot>();
    private void Awake()
    { 
        slots.AddRange(GetComponentsInChildren<ItemInSlot>(false));
    }
    private void Start()
    {
        inventory = InventoryContoller.Instance;
        inventory.onUpdateInventorySlots += UpdateInventorySlots;
    }
    private void OnDisable()
    {
        inventory.onUpdateInventorySlots -= UpdateInventorySlots;
    }
    private void UpdateInventorySlots() //coll from InventoryContoller
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventory.itemsList.Count)
            {
                slots[i].AddItemInSlot(inventory.itemsList[i]); 
            }
            else
            {
                slots[i].CleareInSlot();
            }
        }
    } 
}
