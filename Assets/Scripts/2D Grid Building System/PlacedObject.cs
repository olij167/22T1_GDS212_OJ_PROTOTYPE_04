using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu (menuName = "Placed Objects")]
public class PlacedObject : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public Transform itemPrefab, buildingVisual;
    public int width, height;

    public string plusStat, minusStat;

    //public TextMeshProUGUI plusStatText, minusStatText;

    public List<Vector2Int> GetGridPositionList(Vector2Int offset)
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>();
        for (int x = 0; x < width; x++)
        {
            for (int y= 0; y < height; y++)
            {
                gridPositionList.Add(offset + new Vector2Int(x, y));
            }
        }

        return gridPositionList;
    }

    //public void UseItem()
    //{
    //    //foreach (InventorySlot slot in inventorySlotsList)
    //    //{
    //    //    //slot.itemButton.Select(selectedSlot = slot);
    //    //}

    //}


}
