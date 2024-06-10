 
using UnityEngine; 

public class PickUpItems : Interactable
{   
    [SerializeField] private ItemScrObj item; 
    private InventoryController inventoty; 

    private void Start()
    {
        inventoty  = InventoryController.Instance;
    }
    public override void Interaction()
    {
        base.Interaction();
        PickUpItem();
    }
    private void PickUpItem()
    {   
        if(!item.isDefaultItem)
        {
            bool isPickUp = inventoty.AddItemToInventory(item);
            if (isPickUp)
            {
                Destroy(gameObject);
            }
        } 
    }
}
      
