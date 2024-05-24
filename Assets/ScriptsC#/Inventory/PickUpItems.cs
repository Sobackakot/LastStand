using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItems : MonoBehaviour
{   
    public static PickUpItems Instance;
    public ItemInSlot CurrentItemInSlot;
    public Image currentItemImage;
    public TextMeshProUGUI currentItemText;

    public bool HasCurrentItem => CurrentItemInSlot != null;

    private void Awake()
    {
        Instance = this;
    }
    public void SetCurrentItem(ItemInSlot itemInSlot)
    {
        CurrentItemInSlot = itemInSlot;
        currentItemImage.sprite = CurrentItemInSlot?.Item.spriteItem;
        currentItemText.gameObject.SetActive(true);
        RefreshCurrentItemText();
        currentItemImage.gameObject.SetActive(true);
    }
    public void ResetCurrentItem()
    {
        CurrentItemInSlot = null;
        currentItemImage.sprite = null;
        currentItemText.gameObject.SetActive(false);
        currentItemImage.gameObject.SetActive(false);
    }

    public void RefreshCurrentItemText()
    {
        currentItemText.text = CurrentItemInSlot?.Amount.ToString();
    }
    public void CheckCurrentItem()
    {
        if (CurrentItemInSlot != null && CurrentItemInSlot.Amount < 1)
            ResetCurrentItem();
    }

    private void Update()
    {
        if (CurrentItemInSlot == null)
            return;
        currentItemImage.transform.position = Input.mousePosition;
    }
}
