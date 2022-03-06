using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilgrimAI : MonoBehaviour
{
    public float spiritualStat, physicalStat, mentalStat, socialStat, moveSpeed;
    public float maxSpiritualStat, maxPhysicalStat, maxMentalStat, maxSocialStat;

    public string statToEnrich, firstName, lastName;

    Rigidbody2D rb2D;

    public bool atBuilding = false;

    Transform rightEdgeMarker;

    //PilgrimUI pilgrimUI;

    void Start()
    {
        //pilgrimUI = GameObject.FindGameObjectWithTag("PilgrimUI").GetComponent<PilgrimUI>();
        Mathf.Clamp01(physicalStat);
        Mathf.Clamp01(mentalStat);
        Mathf.Clamp01(spiritualStat);
        Mathf.Clamp01(socialStat);

        rb2D = transform.GetComponent<Rigidbody2D>();

        rightEdgeMarker = GameObject.FindGameObjectWithTag("EndOfScreen").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!atBuilding)
        {
            GoToEnd();
        }
    }

    void GoToEnd()
    {
        transform.position += rightEdgeMarker.position * moveSpeed * Time.deltaTime;
    }

    public void UpdateStats()
    {

    }
}
