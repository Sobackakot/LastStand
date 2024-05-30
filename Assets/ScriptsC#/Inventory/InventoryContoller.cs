
using System;
using System.Collections.Generic;
using UnityEngine; 

public class InventoryContoller : MonoBehaviour
{    
    public static InventoryContoller Instance;
    private Transform inventorySystem;

    [HideInInspector] public DragAndDropItem currentItem; 

    public readonly List<ItemScrObj> itemsList = new List<ItemScrObj>();

    public event Action onUpdateInventorySlots;

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
        inventorySystem = GetComponent<Transform>();  
        currentItem = inventorySystem.GetChild(2).GetComponent<DragAndDropItem>();   
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
