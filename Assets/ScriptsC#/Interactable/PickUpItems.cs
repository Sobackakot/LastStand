 
using UnityEngine; 

public class PickUpItems : Interactable
{   
    [SerializeField] private ItemScrObj item; 
    private InventoryContoller inventoty; 

    private void Start()
    {
        inventoty  = InventoryContoller.Instance;
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
            bool isPickUp = inventoty.AddItemToInventoty(item);
            if (isPickUp)
            {
                Destroy(gameObject);
            }
        } 
    }
}
      
