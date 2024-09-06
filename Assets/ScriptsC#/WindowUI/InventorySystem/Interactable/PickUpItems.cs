
using System;
using UnityEngine;
using Zenject;

public class PickUpItems : Interactable
{   
    [SerializeField] private ItemScrObj item;
    private InventoryController inventory;

    [Inject]
    private void Container(InventoryController inventory)
    {
        this.inventory = inventory;
    }
    public override void Interaction()
    {   
        base.Interaction(); //interaction with default item
        PickUpItem(); //pick up item in inventory
    }
    private void PickUpItem()
    {   
        if(!item.isDefaultItem)
        {
            bool isPickUp = inventory.AddItemToInventory(item);
            if (isPickUp)
            {
                Destroy(gameObject);
            }
        } 
    }
}
      
