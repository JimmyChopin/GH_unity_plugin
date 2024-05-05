using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.Rendering;






[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct ISOBuffer{



}

   

public static class Helper
{
    public static GameObject CreatePlane(float width, float height){

            GameObject go = new GameObject("plane");
            MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
            MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

            Mesh m = new Mesh();
            m.vertices = new Vector3[]{
                new Vector3(0,0,0),
                new Vector3(width,0,0),
                new Vector3(width,height,0),
                new Vector3(0,height,0),
            };

            m.uv = new Vector2[]{
                new Vector2(0,0),
                new Vector2(0,1),
                new Vector2(1,1),
                new Vector2(1,0),
            };

            m.triangles = new int[]{0,2,1,0,3,2};

            mf.mesh = m;
            m.RecalculateBounds();
            m.RecalculateNormals();

            return go;

    }



    // Vertex with FP32 position, FP16 2D normal and a 4-byte tangent.
    // In some cases StructLayout attribute needs
    // to be used, to get the data layout match exactly what it needs to be.
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public  struct isoVertex
    {
        public Vector3 pos;
        public Vector2 uv;
    }

//https://docs.unity3d.com/ScriptReference/Rendering.VertexAttributeDescriptor.html
    public static GameObject CreateDyn(int gridSize){
        GameObject go = new GameObject("plane");
        var mesh = new Mesh();
        // specify vertex count and layout
        var layout = new[]
        {
            new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3),
            new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2),
        };
        var vertexCount = 10;
        mesh.SetVertexBufferParams(vertexCount, layout);

        // set vertex data
        var verts = new NativeArray<isoVertex>(vertexCount, Allocator.Temp);

        // ... fill in vertex array data here...

        mesh.SetVertexBufferData(verts, 0, 0, vertexCount);
        return go;
    }

}
