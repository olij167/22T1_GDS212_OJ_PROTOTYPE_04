using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    //public delegate void SelectAction();
    //public static event SelectAction OnClick;

    public PlacedObject inventoryItem;
    public InventoryController inventoryController;

    public string itemName;
    public Sprite itemIcon;

    public Image itemIconUI;
    public TextMeshProUGUI itemNameUI, plusStatUI, minusStatUI;
    public Button itemButton;

    //private void Start()
    //{
    //    //itemButton.onClick.AddListener(SelectItem);
        
    //}

    //void OnEnable()
    //{
    //    OnClick += SelectItem;
    //}




    public void Set(PlacedObject setItem)
    {
        itemIcon = setItem.itemIcon;
        itemName = setItem.itemName;

        itemIconUI.sprite = itemIcon;
        itemNameUI.text = itemName;
        plusStatUI.text = "+" + setItem.plusStat;
        minusStatUI.text = "-" + setItem.minusStat;


        inventoryItem = setItem;
    }


    public void SelectItem()
    {
        ResetColour();

        inventoryController.selectedSlot = itemButton.GetComponentInParent<InventorySlot>();
        inventoryController.selectedItem = inventoryItem;
        GetComponent<Image>().color = Color.yellow;


    }

    public void ResetColour()
    {
        if (inventoryController.selectedSlot != null)
        {
            inventoryController.selectedSlot.GetComponent<Image>().color = Color.white;
        }
    }

    //private void OnDisable()
    //{
    //    OnClick -= SelectItem;
    //}

    //public void SelectSlot()

}
