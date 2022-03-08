using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingTrigger : MonoBehaviour
{
    //public static BuildingTrigger Create(Vector3 worldPosition, Vector2Int origin, PlacedObject placedObject)
    //{
    //    Transform builtTransform = Instantiate(placedObject.itemPrefab.transform, worldPosition, Quaternion.identity);

    //    BuildingTrigger buildingTrigger = builtTransform.GetComponent<BuildingTrigger>();

    //    buildingTrigger.buildingStats = placedObject;
    //    buildingTrigger.origin = origin;

    //    return buildingTrigger;

    //}

    PilgrimUI pilgrimUI;
    public PlacedObject buildingStats;
    string plusStat, minusStat;

    float statValueChange = 10f;
    float plusStatEffect, minusStatEffect;

    private Vector2Int origin;

    public TextMeshProUGUI plusStatText, minusStatText;

    void Awake()
    {
        pilgrimUI = GameObject.FindGameObjectWithTag("PilgrimUI").GetComponent<PilgrimUI>();
        plusStat = buildingStats.plusStat;
        minusStat = buildingStats.minusStat;

        plusStatText.text = "+" + plusStat;
        minusStatText.text = "-" + minusStat;

        origin = new Vector2Int((int)transform.position.x, (int)transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PilgrimAI>())
        {
            PlusStatEffects(other.gameObject.GetComponent<PilgrimAI>());
            MinusStatEffects(other.gameObject.GetComponent<PilgrimAI>());

            if (pilgrimUI.selectedPilgrim == other.gameObject.GetComponent<PilgrimAI>())
            {
                pilgrimUI.UpdatePilgrimUI();
            }
        }
    }

    public float PlusStatEffects(PilgrimAI pilgrim)
    {
        switch (plusStat)
        {
            case "Physical":
                {
                    plusStatEffect = pilgrim.gameObject.GetComponent<PilgrimAI>().physicalStat += statValueChange;
                    break;
                }

            case "Mental":
                {
                    plusStatEffect = pilgrim.gameObject.GetComponent<PilgrimAI>().mentalStat += statValueChange;
                    break;
                }
            case "Spiritual":
                {
                    plusStatEffect = pilgrim.gameObject.GetComponent<PilgrimAI>().spiritualStat += statValueChange;
                    break;
                }
            case "Social":
                {
                    plusStatEffect = pilgrim.gameObject.GetComponent<PilgrimAI>().socialStat += statValueChange;
                    break;
                }
            case null:
                {
                    break;
                }
        }
        return plusStatEffect;
    }
    
    public float MinusStatEffects(PilgrimAI pilgrim)
    {
        switch (minusStat)
        {
            case "Physical":
                {
                    minusStatEffect = pilgrim.gameObject.GetComponent<PilgrimAI>().physicalStat -= statValueChange;
                    break;
                }

            case "Mental":
                {
                    minusStatEffect = pilgrim.gameObject.GetComponent<PilgrimAI>().mentalStat -= statValueChange;
                    break;
                }
            case "Spiritual":
                {
                    minusStatEffect = pilgrim.gameObject.GetComponent<PilgrimAI>().spiritualStat -= statValueChange;
                    break;
                }
            case "Social":
                {
                    minusStatEffect = pilgrim.gameObject.GetComponent<PilgrimAI>().socialStat -= statValueChange;
                    break;
                }
            case null:
                {
                    break;
                }
        }
        return minusStatEffect;
    }

    public List<Vector2Int> GetGridPositionList()
    {
        return buildingStats.GetGridPositionList(origin);
    }

    public void DestroySelf()
    {
        Destroy(transform);
    }

}
