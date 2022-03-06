using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridBuildingSystem : MonoBehaviour
{
    private Grid2D<GridObject> grid, visualGrid;
    Vector3 originPosition;
    public ItemsList placedObjectList;
    public PlacedObject selectedObject;
    public MousePosition mousePos;
    public InventoryController inventoryController;
    public int gridWidth = 10;
    public int gridHeight = 1;
    public float cellSize = 1f;
    public GameHandler gameHandler;

    //[SerializeField] private BuildAreaVisual buildAreaVisual;


    void Awake()
    {
        originPosition = transform.position;
        //int gridWidth = 10;
        //int gridHeight = 1;
        //float cellSize = 1f;
        

        grid = new Grid2D<GridObject>(gridWidth, gridHeight, cellSize, originPosition, (Grid2D<GridObject> g, int x, int y) => new GridObject(g, x, y)); //(Grid2D<GridObject> g, int x, int y) => new GridObject(g, x, y)
        //visualGrid = new Grid2D<bool>(gridWidth, gridHeight, cellSize, originPosition, (Grid2D<bool> g, int x, int y) => new bool(g, x, y)); 

        //visualGrid = new Grid2D<bool>();
        //buildAreaVisual.SetGrid(grid);
    }

    public class GridObject
    {
        private Grid2D<GridObject> grid;
        private int x;
        private int y;
        private Transform transform;
        //private Mesh mesh;
        //private bool updateMesh;

        //private bool canBuild;

        public GridObject(Grid2D<GridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
            //this.mesh = mesh;
            //this.canBuild = canBuild;
        }

        public void SetTransform(Transform transform)
        {
            this.transform = transform;
            //UpdateBuildAreaVisual();
            grid.TriggerGridObjectChanged(x, y);
            

        }

        public void ClearTransform()
        {
            transform = null;
            //UpdateBuildAreaVisual();
            grid.TriggerGridObjectChanged(x, y);

        }

        public bool CanBuild()
        {
            return transform == null;
        }

        //public Color SetCellColour()
        //{
        //    if (CanBuild())
        //    {
        //        return Color.green;
        //    }
        //    else return Color.red;
        //}

        //public void SetMesh()
        //{
        //    mesh = new Mesh();
        //    this.transform.GetComponent<MeshFilter>().mesh = mesh;
        //}
        //public void UpdateBuildAreaVisual()
        //{
        //    MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] vertices, out Vector2[] uv, out int[] triangles);

        //    for (int x = 0; x < grid.GetWidth(); x++)
        //    {
        //        for (int y = 0; y < grid.GetHeight(); y++)
        //        {
        //            int index = x * grid.GetHeight() + y;
        //            Vector3 quadSize = new Vector3(1, 1) * grid.GetCellSize();

        //            bool gridValue = grid.GetGridObject(x, y).CanBuild();
        //            float gridValueNormalised = gridValue ? 1f : 0f;
        //            Vector2 gridValueUV = new Vector2(gridValueNormalised, 0f);
        //            MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, grid.GetWorldPosition(x, y) + quadSize * .5f, 0f, quadSize, gridValueUV, gridValueUV);
        //        }
        //    }
        //}

        //public override string ToString()
        //{
        //    return x + ", " + y + "\n" + transform;
        //}
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedObject != null)
        {
            grid.GetXY(mousePos.whereToBe, out int x, out int y);

            List<Vector2Int> gridPositionList = selectedObject.GetGridPositionList(new Vector2Int(x, y));

            GridObject gridObject = grid.GetGridObject(x, y);

            bool canBuild = true;

            foreach(Vector2Int gridPosition in gridPositionList)
            {
                if (!grid.GetGridObject(gridPosition.x, gridPosition.y).CanBuild())
                {
                    //Can't build
                    canBuild = false;
                    break;
                }
            }

            if (canBuild)
            {
               GameObject builtTransform = Instantiate(selectedObject.itemPrefab.gameObject, grid.GetWorldPosition(x, y), Quaternion.identity);

                //gameHandler.buildingsList.Add(builtTransform.transform);
                //gameHandler.AddBuildingButton(builtTransform.transform);

                foreach (Vector2Int gridPosition in gridPositionList)
                {
                    grid.GetGridObject(gridPosition.x, gridPosition.y).SetTransform(builtTransform.transform);
                    //grid.GetGridObject(gridPosition.x, gridPosition.y).SetCellColour();
                    //grid.GetGridObject(gridPosition.x, gridPosition.y).UpdateBuildAreaVisual();
                }

                inventoryController.SetNewItem(inventoryController.selectedSlot);

                inventoryController.selectedItem = null;
                inventoryController.selectedSlot = null;

                //InventoryController.OnSelectedItemChanged -= inventoryController.selectedSlot.
                //gridObject.SetTransform(builtTransform);
            }
            else
            {
                UtilsClass.CreateWorldTextPopup("Cannot build here", mousePos.whereToBe);
            }
        }

        if (inventoryController.selectedItem != null)
            selectedObject = inventoryController.selectedItem;
        else selectedObject = default;
    }


}

