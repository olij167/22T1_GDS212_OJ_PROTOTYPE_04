using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Vector3 whereToBe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        //mousePos.z = Camera.main.nearClipPlane;
        mousePos.z = 1f;
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        //Vector2 Worldpos2D = new Vector2(Worldpos.x, Worldpos.y);
        whereToBe = new Vector3(Worldpos.x, Worldpos.y, mousePos.z);
        transform.position = whereToBe;
        //Debug.Log(whereToBe);
    }

}
