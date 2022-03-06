using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<InventorySlot> inventorySlotsList;

    public InventorySlot selectedSlot;
    public PlacedObject selectedItem;

    public ItemsList allItems;

    //public InventorySlot selectedSlot;

    // Start is called before the first frame update
    void Start()
    {
        SetAllItems();
        //selectedSlot = inventorySlotsList[0];
    }

    public void SetAllItems() // potential for refresh button?
    {
        foreach (InventorySlot slot in inventorySlotsList)
        {
            slot.Set(allItems.RandomiseItem());
        }
    }

    public void SetNewItem(InventorySlot item) // called when an item is placed
    {
        item.Set(allItems.RandomiseItem());
    }


}
