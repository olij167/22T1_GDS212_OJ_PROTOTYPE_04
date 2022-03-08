using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Vector3 whereToBe;

    public PilgrimUI pilgrimUI;

    public PilgrimAI selectedPilgrim;

    public SpawnPilgrim spawn;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        //mousePos.z = Camera.main.nearClipPlane;
        mousePos.z = -1f;
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        //Vector2 Worldpos2D = new Vector2(Worldpos.x, Worldpos.y);
        whereToBe = new Vector3(Worldpos.x, Worldpos.y, mousePos.z);
        transform.position = whereToBe;

        //if (Input.GetMouseButtonDown(0))
        //{
        //    SetNewPilgrim();
        //}
    }

    void SetNewPilgrim()
    {
        

        //selectedPilgrim = pilgrimUI.selectedPilgrim;
        //Debug.Log(whereToBe);
        //RaycastHit2D hit;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        {
            if (hit.transform.CompareTag("Pilgrim"))
            {

                selectedPilgrim = hit.transform.GetComponent<PilgrimAI>();
                selectedPilgrim = hit.transform.GetComponent<PilgrimAI>();
                pilgrimUI.selectedPilgrim = selectedPilgrim;
                pilgrimUI.UpdatePilgrimUI();

            }
            else
            {
                Debug.Log(hit.transform.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Pilgrim"))
        {
            selectedPilgrim = other.transform.GetComponent<PilgrimAI>();
            selectedPilgrim = other.transform.GetComponent<PilgrimAI>();
            pilgrimUI.selectedPilgrim = selectedPilgrim;
            pilgrimUI.UpdatePilgrimUI();
        }
    }
}
