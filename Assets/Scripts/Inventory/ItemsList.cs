using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Placeable Items List")]
public class ItemsList : ScriptableObject
{
    public List<PlacedObject> placedObjectsList;

    public PlacedObject RandomiseItem()
    {
        return placedObjectsList[Random.Range(0, placedObjectsList.Count)];
    }
}
