using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GridScript : MonoBehaviour {
    public int xSize, ySize;
    private Vector3[] vertices;
    private Mesh mesh;

    // Use this for initialization
    void Awake()
    {
        generate();
    }

    private void generate()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "DerpMap";

        vertices = new Vector3[((xSize) * (ySize)*4)];
        int[] triangles = new int[xSize * ySize * 6];
        Vector2[] uv = new Vector2[vertices.Length];
        for (int i=0, y=0, ti=0; y<ySize; y++)
        {
            for (int x=0; x< xSize; x++, i+=4, ti+=6)
            {
                vertices[i] = new Vector3(x, y);
                vertices[i + 1] = new Vector3(x, y+1);
                vertices[i + 2] = new Vector3(x+1, y + 1);
                vertices[i + 3] = new Vector3(x+1, y);
                triangles[ti] = i;
                triangles[ti + 3] = triangles[ti + 2] = i + 1;
                triangles[ti + 4] = triangles[ti + 1] = i + 3;
                triangles[ti + 5] = i + 2;
                uv[i] = new Vector2(0, 7.0f/8);
                uv[i + 1] = new Vector2(0, 1);
                uv[i + 2] = new Vector2(1.0f / 8, 1);
                uv[i + 3] = new Vector2(1.0f / 8, 7.0f / 8);
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
    void Update () {
	
	}
}
