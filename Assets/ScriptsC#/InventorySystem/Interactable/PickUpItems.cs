
using UnityEngine; 

public class PickUpItems : Interactable
{   
    [SerializeField] private ItemScrObj item; 
    private InventoryController inventory; 

    private void Start()
    {
        inventory = InventoryController.Instance; 
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
      
