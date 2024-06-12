
using System;
using System.Collections.Generic;
using UnityEngine; 

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;

    public ItemScrObj[] itemsArray; // Fixed-size array
    public event Action onUpdateInventorySlots; // Event for InventoryUI

    private int space = 48;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        itemsArray = new ItemScrObj[space];
    }

    public bool AddItemToInventory(ItemScrObj newItem) //coll from EquipmentController
    {
        for (int i = 0; i < itemsArray.Length; i++)
        {
            if (itemsArray[i] == null)
            {
                itemsArray[i] = newItem;
                onUpdateInventorySlots?.Invoke();
                return true;
            }
        }
        return false; // InventoryPerson is full
    }

    public void RemoveItemFromInventory(ItemScrObj item) // coll from ItemScrObj
    {
        for (int i = 0; i < itemsArray.Length; i++)
        {
            if (itemsArray[i] == item)
            {
                itemsArray[i] = null;
                onUpdateInventorySlots?.Invoke();
                return;
            }
        }
    }
}
