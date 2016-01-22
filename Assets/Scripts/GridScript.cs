using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GridScript : MonoBehaviour {
    private int xSize, ySize;
    private Vector3[] vertices;
    private Mesh mesh;

    // Use this for initialization
    void Start()
    {
        generate();
    }

    private void generate()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "DerpMap";

        TileSheetScript tileSheetScript = GetComponent<TileSheetScript>();
        xSize = tileSheetScript.xSize;
        ySize = tileSheetScript.ySize;

        vertices = new Vector3[((xSize) * (ySize)*4)];
        int[] triangles = new int[xSize * ySize * 6];
        Vector2[] uv = new Vector2[vertices.Length];
        for (int i=0, y=-1, ti=0, ty=0; y>=-(ySize); y--, ty++)
        {
            for (int x=0, tx=0; x< xSize; x++, i+=4, ti+=6, tx++)
            {
                vertices[i] = new Vector3(x, y);
                vertices[i + 1] = new Vector3(x, y+1);
                vertices[i + 2] = new Vector3(x+1, y + 1);
                vertices[i + 3] = new Vector3(x+1, y);
                triangles[ti] = i;
                triangles[ti + 3] = triangles[ti + 2] = i + 1;
                triangles[ti + 4] = triangles[ti + 1] = i + 3;
                triangles[ti + 5] = i + 2;
                Vector2[] corners= tileSheetScript.getTile(tx,ty);
                uv[i] = new Vector2(corners[0].x, corners[1].y);
                uv[i + 1] = new Vector2(corners[0].x, corners[0].y);
                uv[i + 2] = new Vector2(corners[1].x, corners[0].y);
                uv[i + 3] = new Vector2(corners[1].x, corners[1].y);
            }
        }
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    //private void OnDrawGizmos()
    //{
    //    if (vertices == null)
    //    {
    //        return;
    //    }
    //    Gizmos.color = Color.black;
    //    for (int i = 0; i < vertices.Length; i++)
    //    {
    //        Gizmos.DrawSphere(vertices[i], 0.1f);
    //    }
    //}

    // Update is called once per frame
}
