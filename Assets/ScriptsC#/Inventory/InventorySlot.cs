using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot :MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    private Image slotImage;
    private Image itemImage;
    private TextMeshProUGUI amountItemText;
    private TextMeshProUGUI nameItemText;

    public ItemInSlot itemInSlot;
    private ItemInSlot currentItem;
    public bool HasItem => itemInSlot != null;

    private int TotalAmountItemInSlot { get; set; }

    public const int maxItemAmount = 64;

    private Color defaultColor = new Color(140f / 255f, 140f / 255f, 140f / 255f, 1f);
    private Color highlightedColor = new Color(120f / 255f, 120f / 255f, 120f / 255f, 1f);
    private void Awake()
    {
        slotImage = GetComponent<Image>();
        itemImage = transform.GetChild(0).GetComponent<Image>();
        amountItemText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        nameItemText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        if (HasItem)
        {
            nameItemText.transform.position = Input.mousePosition;
        }
    }
    // system functions!!!
    public void OnPointerClick(PointerEventData eventData) //IPointerClickHandler - listens to the click
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            LeftMouseClick();
        else
            RightMouseClick();
    }
    public void OnPointerEnter(PointerEventData eventData) // IPointerEnterHandler - Show name item in slot and color slot
    {
        slotImage.color = highlightedColor;
        if (HasItem)
            nameItemText.text = currentItem.Item.name;
    }
    public void OnPointerExit(PointerEventData eventData) // IPointerExitHandler - Break show name and color slot
    {
        slotImage.color = defaultColor;
        nameItemText.gameObject.SetActive(false);
    }
    // !!! EXTERNOL METHODS !!!
    public virtual void LeftMouseClick() //OnPointerClick
    {
        currentItem = PickUpItems.Instance.CurrentItemInSlot;
        if (HasItem)
        {
            if (currentItem == null)
                PickUpItemsInSlot();
            else if (itemInSlot.Item != currentItem.Item)
                SwapingDifferentItems();
            else SetItemsInSlot();
        }
        else SetAllItemsInSlot();
    }
    public virtual void RightMouseClick() //OnPointerClick
    {
        if (!PickUpItems.Instance.HasCurrentItem && HasItem)
        {
            if (itemInSlot.Amount <= 1) return;
            GetHalfAmount();
        }
        else if (!HasItem || (PickUpItems.Instance.CurrentItemInSlot.Item == itemInSlot.Item && itemInSlot.Amount < maxItemAmount))
            IncrementItemInSlot();
    }
    public void SetItem(ItemInSlot item) // Turn on item in the slot
    {
        itemInSlot = item;
        RefreshUI();
    }
    public void ResetItem() // Turn of item in the slot
    {
        itemInSlot = null;
        RefreshUI();
    }
    public void RefreshUI() // Update the sprite and text of the item
    {
        itemImage.gameObject.SetActive(HasItem);
        itemImage.sprite = itemInSlot?.Item.spriteItem;
        amountItemText.gameObject.SetActive(HasItem);
        amountItemText.text = itemInSlot?.Amount.ToString();
    }
    public void AddItem(ItemInSlot Items, int amountCurrentItem) // Ñalculates and transfers items to the slot from the current
    {
        Items.Amount -= amountCurrentItem;
        if (!HasItem)
            SetItem(new ItemInSlot(Items.Item, amountCurrentItem));
        else if (itemInSlot.Amount < maxItemAmount)
            SumAmountItemsInSlot(Items, amountCurrentItem);
        else
            SwapingAmountItems(Items, amountCurrentItem);
    }
    // !!! INTERNOL METHODS !!!
    private void SumAmountItemsInSlot(ItemInSlot Items, int amountCurrentItem) // AddItem - The sum of the addition of items from the slot and the current
    {
        TotalAmountItemInSlot = itemInSlot.Amount + amountCurrentItem;
        if (TotalAmountItemInSlot > maxItemAmount)
            SetPartAmountItemsCurrent(Items, amountCurrentItem);
        else SetMaxAmountItemsInSlot(Items, amountCurrentItem);
    }
    private void SwapingAmountItems(ItemInSlot Items, int amountCurrentItem) // AddItem - There is an exchange of the number of items in the slot and in the current
    {
        PickUpItems.Instance.SetCurrentItem(itemInSlot);
        SetItem(new ItemInSlot(Items.Item, amountCurrentItem));
        RefreshUI();
    }
    private void SetMaxAmountItemsInSlot(ItemInSlot Items, int amountCurrentItem) //SumOfAddItem- Increment the amount of items in the slot at the expense of the current item
    {
        itemInSlot.Amount = TotalAmountItemInSlot;
        RefreshUI();
    }
    private void SetPartAmountItemsCurrent(ItemInSlot Items, int amountCurrentItem) //SumOfAddItem - Fills the amount of items in the slot from the current item to the maximum
    {
        int excessAmount = TotalAmountItemInSlot - maxItemAmount;
        itemInSlot.Amount = maxItemAmount;
        PickUpItems.Instance.SetCurrentItem(new ItemInSlot(Items.Item, excessAmount));
        RefreshUI();
    }
    private void PickUpItemsInSlot() //LeftMouseClick - Pick up items from the slot in the current one
    {
        PickUpItems.Instance.SetCurrentItem(itemInSlot);
        ResetItem();
    }
    private void SwapingDifferentItems() //LeftMouseClick - Swapping different items between slot and current one
    {
        PickUpItems.Instance.SetCurrentItem(itemInSlot);
        SetItem(currentItem);
    }
    private void SetItemsInSlot() //LeftMouseClick - Returns some of the items in the slot from the current
    {
        AddItem(currentItem, currentItem.Amount);
        PickUpItems.Instance.CheckCurrentItem();
        return;
    }
    private void SetAllItemsInSlot() //LeftMouseClick - Returns all items in the slot from the current
    {
        PickUpItems.Instance.ResetCurrentItem();
        if (currentItem != null)
        {
            SetItem(currentItem);
        }
    }
    private void GetHalfAmount() // RightMouseClick - Takes items from the slot exactly half of the amount into the current items
    {
        int amountHalf = Mathf.CeilToInt(itemInSlot.Amount * 0.5f);
        itemInSlot.Amount -= amountHalf;
        PickUpItems.Instance.SetCurrentItem(new ItemInSlot(itemInSlot.Item, amountHalf));
        SetItem(itemInSlot);
    }

    private void IncrementItemInSlot() // RightMouseClick - Adds one and the same item to the slot in 1 click.
    {
        if (PickUpItems.Instance.HasCurrentItem)
            AddItem(PickUpItems.Instance.CurrentItemInSlot, 1);
        PickUpItems.Instance.CheckCurrentItem();
        PickUpItems.Instance.RefreshCurrentItemText();
    }
}
