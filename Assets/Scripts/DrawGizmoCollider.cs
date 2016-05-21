using UnityEngine;
using System.Collections;

public class DrawGizmoCollider : MonoBehaviour
{
    Color ForceFieldCol = new Color(0.2f, 0.2f, 1, 0.8f);
    Color BGCol = new Color(0.2f, 0.9f, 0.2f, 0.5f);
    void OnDrawGizmos()
    {
        PolygonCollider2D pc2 = gameObject.GetComponent<PolygonCollider2D>();
        int pointCount = pc2.GetTotalPointCount();

        Mesh mesh = new Mesh();
        Vector2[] points = pc2.points;
        Vector3[] vertices = new Vector3[pointCount];

        for (int i = 0; i < pointCount;i++ )
        {
            Vector2 actual = points[i];
            vertices[i] = new Vector3(actual.x, actual.y, 0);
        }

        Triangulator tr = new Triangulator(points);
        int[] triangles = tr.Triangulate();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        Color col = new Color();
        switch(gameObject.tag)
        {
            case "StaticMesh":
                col = GetComponent<Renderer>().sharedMaterial.color;
                break;
            case "ForceField":
                col = ForceFieldCol;
                break;
            case "BG":
                col = BGCol;
                break;
        }

        Color[] colors = new Color[mesh.vertexCount];
        for (int i = 0; i < mesh.vertexCount;i++ )
        {
            colors[i] = col;
        }
        mesh.colors = colors;

        Graphics.DrawMeshNow(mesh, transform.position, Quaternion.identity);

        DestroyImmediate(mesh);
    }
}