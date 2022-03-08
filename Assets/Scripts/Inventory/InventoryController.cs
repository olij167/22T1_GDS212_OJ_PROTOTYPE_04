using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryController : MonoBehaviour
{
    public List<InventorySlot> inventorySlotsList;

    public InventorySlot selectedSlot;
    public PlacedObject selectedItem;

    public ItemsList allItems;

    public Button refreshButton;

    public TextMeshProUGUI refreshesLeftText, refreshButtonText;

    public int refreshLimit = 5, refreshPressCount;

    //public InventorySlot selectedSlot;

    // Start is called before the first frame update
    void Start()
    {
        SetAllItems();

        refreshButtonText.text = "Refresh";
        refreshesLeftText.text = (refreshLimit - refreshPressCount).ToString() + " uses left";

        //selectedSlot = inventorySlotsList[0];
    }

    public void RefreshButtonPressed()
    {
        if (refreshPressCount < refreshLimit)
        {
            refreshPressCount++;

            refreshButtonText.text = "Refresh";
            refreshesLeftText.text = (refreshLimit - refreshPressCount).ToString() + " uses left";

            if (refreshPressCount >= refreshLimit)
            {
                refreshButton.interactable = false;
                refreshButtonText.text = "Out of Refreshes";
                refreshesLeftText.enabled = false;
            }
        }
    }

    public void SetAllItems() // potential for refresh button?
    {
        foreach (InventorySlot slot in inventorySlotsList)
        {
            PlacedObject newItem = allItems.RandomiseItem();
            
            if (slot.inventoryItem == newItem)
            {
                newItem = allItems.RandomiseItem();
                return;
            }

            slot.Set(newItem);
        }
    }

    //public void SetNewItem(InventorySlot item) // called when an item is placed
    //{
    //    item.Set(allItems.RandomiseItem());
    //}

    public void SetNewItem(InventorySlot item) // called when an item is placed
    {
        PlacedObject newItem = allItems.RandomiseItem();

        foreach (InventorySlot slot in inventorySlotsList)
        {
            if (newItem == slot.inventoryItem)
            {
                newItem = allItems.RandomiseItem();
                return;
            }
        }

        item.Set(newItem);
    }


}
