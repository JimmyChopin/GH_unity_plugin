using UnityEngine;
using UnityEngine.Rendering;

public class Hello : MonoBehaviour
{
    private Mesh mesh;
    private Material material;

    void Start()
    {
        // Create a new mesh
        mesh = new Mesh();

        // Define vertices for a triangle
        Vector3[] vertices = new Vector3[3];
        vertices[0] = new Vector3(0, 0, 50);  // Vertex 0 (bottom)
        vertices[1] = new Vector3(100, 50, 0);  // Vertex 1 (bottom-right)
        vertices[2] = new Vector3(50, 0, 0);  // Vertex 2 (top-middle)

        // Set the vertex buffer data
        mesh.SetVertexBufferParams(3, new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3));
        mesh.SetVertexBufferData(vertices, 0, 0, 3);

        // Define triangles
        int[] triangles = new int[] { 0, 1, 2 };
        mesh.SetTriangles(triangles, 0);

        // Recalculate normals for proper lighting
        mesh.RecalculateNormals();


        // Assign the created mesh to a MeshFilter component
        GetComponent<MeshFilter>().mesh = mesh;
        // // Create a simple material
        // material = new Material(Shader.Find("Standard"));

        // // Optional: Set material color
        // material.color = Color.red;
        // Debug.Log(mesh);

    }

    void OnRenderObject()
    {
        // Draw the mesh using the assigned material
        Graphics.DrawMeshNow(mesh, Vector3.zero, Quaternion.identity);
    }
}