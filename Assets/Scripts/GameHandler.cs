using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;

    private Vector3 cameraFollowPosition;
    
    public Transform mouseTransform, leftEdgeMarker, rightEdgeMarker;

    [SerializeField] private float edgeSize = 30f, moveAmount = 20f, scrollWheelMoveAmount = 100f;

    float trailLength, distanceFromLeftEdge, distanceFromRightEdge, distanceAlongTrail;

    public List<Transform> buildingsList;//, pilgrimsList;

    public Scrollbar cameraScrollBar;

    void Start()
    {
        trailLength = Vector3.Distance(leftEdgeMarker.position, rightEdgeMarker.position);

        

        buildingsList = new List<Transform>();
        //pilgrimsList = new List<Transform>();

        cameraFollow.Setup(() => cameraFollowPosition);

        //cameraFollow.SetGetCameraFollowPositionFunc(() => buildingsList[0].position);

        //foreach (Transform building in buildingsList)
        //{
        //    CMDebug.ButtonUI(new Vector2(570, 330), building.GetComponent<PlacedObject>().itemName, () =>
        //    {
        //        cameraFollow.SetGetCameraFollowPositionFunc(() => building.position);
        //    });
        //}



        //distanceAlongTrail = Mathf.Clamp01(distanceFromLeftEdge / distanceFromRightEdge);



        //foreach (Transform pilgrim in pilgrimsList)
        //{
        //    CMDebug.ButtonUI(new Vector2(570, 330), pilgrim.GetComponent<PlacedObject>().itemName, () =>
        //    {
        //        cameraFollow.SetGetCameraFollowPositionFunc(() => pilgrim.position);
        //    });
        //}
    }

    private void Update()
    {
        // key input camera movement
        if (Input.GetKey(KeyCode.A))
        {
            cameraFollowPosition.x -= moveAmount * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            cameraFollowPosition.x += moveAmount * Time.deltaTime;
        }
        
        // scroll wheel input camera movement
        if (Input.mouseScrollDelta.y < 0)
        {
            cameraFollowPosition.x -= scrollWheelMoveAmount * Time.deltaTime;
        }
        
        if (Input.mouseScrollDelta.y > 0)
        {
            cameraFollowPosition.x += scrollWheelMoveAmount * Time.deltaTime;
        }


        // mouse edge scrolling camera movement
        if (Input.mousePosition.x > Screen.width - edgeSize)
        {
            cameraFollowPosition.x += moveAmount * Time.deltaTime;
        }
        
        if (Input.mousePosition.x < edgeSize)
        {
            cameraFollowPosition.x -= moveAmount * Time.deltaTime;
        }

        ScrollBarFollowCamera();


        // start & end of screen limits
        if (cameraFollowPosition.x <= leftEdgeMarker.position.x)
        {
            cameraFollowPosition.x = leftEdgeMarker.position.x;
        }

        if (cameraFollowPosition.x >= rightEdgeMarker.position.x)
        {
            cameraFollowPosition.x = rightEdgeMarker.position.x;
            //cameraScrollBar.value = 1f;
        }



    }

    void ScrollBarFollowCamera()
    {
        distanceAlongTrail = Mathf.Clamp(cameraFollowPosition.x, leftEdgeMarker.position.x, trailLength) / trailLength;


        cameraScrollBar.value = distanceAlongTrail;
    }

    public void ScrollBarMoveCamera()
    {
        distanceAlongTrail = cameraScrollBar.value;
        cameraFollowPosition.x = distanceAlongTrail * trailLength;
    }


    public void AddBuildingButton(Transform building)
    {
        cameraFollow.SetGetCameraFollowPositionFunc(() => buildingsList[0].position);

        CMDebug.ButtonUI(new Vector2(570, 330), building.GetComponent<PlacedObject>().itemName, () =>
        {
            cameraFollow.SetGetCameraFollowPositionFunc(() => building.position);
        });
    }
    
    public void AddPilgrimButton(Transform pilgrim)
    {
        CMDebug.ButtonUI(new Vector2(570, 330), pilgrim.GetComponent<PlacedObject>().itemName, () =>
        {
            cameraFollow.SetGetCameraFollowPositionFunc(() => pilgrim.position);
        });
    }
}
