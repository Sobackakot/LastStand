

using System.Collections.Generic;
using UnityEngine;

public class InventotyUI : MonoBehaviour
{
    private InventoryContoller inventory; 
    private List<InventorySlot> slots = new List<InventorySlot>();
    private void Awake()
    { 
        slots.AddRange(GetComponentsInChildren<InventorySlot>(false));
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
                slots[i].AddItemToSlot(inventory.itemsList[i]);
            }
            else
            {
                slots[i].CleareSlot();
            }
        }
    }
}
