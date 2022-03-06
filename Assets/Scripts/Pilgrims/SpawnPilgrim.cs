using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPilgrim : MonoBehaviour
{
    public Transform pilgrim, spawnPos;
    
    public float minTimer, maxTimer;
    float spawnTimer, timerReset;

    public List<Transform> pilgrimList;

    public NameGenerator nameGenerator;

    public PilgrimUI pilgrimUI;
    void Start()
    {
        pilgrimList = new List<Transform>();

        SpawnNewPilgrim();

        //pilgrimUI.gameObject.SetActive(true);
        //pilgrimUI.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnNewPilgrim();

        }
    }

    void ResetTimer()
    {
        spawnTimer = Random.Range(minTimer, maxTimer);
    }

    //public void RandomiseStats(PilgrimAI newPilgrimAI)
    //{
    //    newPilgrimAI.physicalStat = Random.Range(0, 0.5f);
    //    newPilgrimAI.mentalStat = Random.Range(0, 0.5f);
    //    newPilgrimAI.spiritualStat = Random.Range(0, 0.5f);
    //    newPilgrimAI.socialStat = Random.Range(0, 0.5f);

    //    int randomStat = Random.Range(0, 4);

    //    switch (randomStat)
    //    {
    //        case 0:
    //            {
    //                newPilgrimAI.statToEnrich = "Physical";
    //                break;
    //            }
    //        case 1:
    //            {
    //                newPilgrimAI.statToEnrich = "Mental";
    //                break;
    //            } 
    //        case 2:
    //            {
    //                newPilgrimAI.statToEnrich = "Social";
    //                break;
    //            }
    //        case 3:
    //            {
    //                newPilgrimAI.statToEnrich = "Spiritual";
    //                break;
    //            }
    //    }
    //}

    void SpawnNewPilgrim()
    {
        Transform newPilgrim = Instantiate(pilgrim, spawnPos);

        PilgrimAI newPilgrimAI = newPilgrim.GetComponent<PilgrimAI>();
        //RandomiseStats(newPilgrimAI);

        newPilgrimAI.physicalStat = Random.Range(0, newPilgrimAI.maxPhysicalStat / 2f);
        newPilgrimAI.mentalStat = Random.Range(0, newPilgrimAI.maxMentalStat / 2f);
        newPilgrimAI.spiritualStat = Random.Range(0, newPilgrimAI.maxSpiritualStat / 2f);
        newPilgrimAI.socialStat = Random.Range(0, newPilgrimAI.maxSocialStat / 2f);

        int randomStat = Random.Range(0, 4);

        switch (randomStat)
        {
            case 0:
                {
                    newPilgrimAI.statToEnrich = "Physical";
                    break;
                }
            case 1:
                {
                    newPilgrimAI.statToEnrich = "Mental";
                    break;
                }
            case 2:
                {
                    newPilgrimAI.statToEnrich = "Social";
                    break;
                }
            case 3:
                {
                    newPilgrimAI.statToEnrich = "Spiritual";
                    break;
                }
        }

        newPilgrimAI.firstName = nameGenerator.GetRandomFirstName();
        newPilgrimAI.lastName = nameGenerator.GetRandomFLastName();

        newPilgrim.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 0.5f, 0.75f, 0.5f, 0.75f);

        newPilgrim.parent = null;

        pilgrimList.Add(newPilgrim);

        ResetTimer();
    }
}
