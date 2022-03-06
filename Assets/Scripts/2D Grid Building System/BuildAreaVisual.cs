using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAreaVisual : MonoBehaviour
{
    private Grid2D<bool> grid;
    private Mesh mesh;
    //private bool updateMesh;

    private void Awake()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }
    public void SetGrid(Grid2D<bool> grid)
    {
        this.grid = grid;
        UpdateBuildAreaVisual();

        //grid.OnGridObjectChanged += Grid_OnGridObjectChanged;
    }

    private void Grid_OnGridObjectChanged(object sender, Grid2D<bool> e)
    {
        //updateMesh = true;
        UpdateBuildAreaVisual();

    }

    private void UpdateBuildAreaVisual()
    {
        MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] vertices, out Vector2[] uv, out int[] triangles);

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                int index = x * grid.GetHeight() + y;
                Vector3 quadSize = new Vector3(1, 1) * grid.GetCellSize();

                bool gridValue = grid.GetGridObject(x, y);
                float gridValueNormalised = gridValue ? 1f : 0f;
                Vector2 gridValueUV = new Vector2(gridValueNormalised, 0f);
                MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, grid.GetWorldPosition(x, y) + quadSize * .5f, 0f, quadSize, gridValueUV, gridValueUV);
            }
        }
    }
}
