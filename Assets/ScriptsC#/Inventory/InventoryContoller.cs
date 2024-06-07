
using System;
using System.Collections.Generic;
using UnityEngine; 

public class InventoryContoller : MonoBehaviour
{    
    public static InventoryContoller Instance; 

    public readonly List<ItemScrObj> itemsList = new List<ItemScrObj>();

    public event Action onUpdateInventorySlots; // Event for class InventoryUI

    private int space = 48;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }
    public bool AddItemToInventoty(ItemScrObj newItem) //call from  PickUpItems 
    {
        if (itemsList.Count >= space) return false;
        itemsList.Add(newItem);
        onUpdateInventorySlots?.Invoke();
        return true;
    }
    public void RemoveItemFromInventoty(ItemScrObj newItem)
    { 
        itemsList.Remove(newItem);
        onUpdateInventorySlots?.Invoke();
    } 
}
