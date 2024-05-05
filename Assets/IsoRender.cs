// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Unity.Collections ;

// public class IsoRender : MonoBehaviour
// {
//     public Material material;
//     GraphicsBuffer buffer;
//     GraphicsBuffer dataBuffer;
    
//     void Start()
//     {    // note: remember to check "Read/Write" on the mesh asset to get access to the geometry data
//         buffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, 6, 2 * sizeof(float));
//         NativeArray<float> bufferArray =  new NativeArray<float>(12, Allocator.Temp){
//             [0] = 0,[1] = 0,
//             [4] = 10,[5] = -10,
//             [2] = 0,[3] = -10,


//             [6] = 10,[7] = -10, 
//             [10] = 0,[11] = 0,
//             [8] = 10,[9] = 0,      
//         };

//         buffer.SetData(bufferArray);



//         dataBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, 1, 2 * sizeof(float));
//         NativeArray<float> dataBufferArr =  new NativeArray<float>(12, Allocator.Temp){
//             [0] = 0,[1] = 0,
//         };

//         buffer.SetData(dataBufferArr);

//     }
//     void OnDestroy(){
//         buffer?.Dispose();
//         buffer = null;

//     }

//     // Update is called once per frame
// void Update()
//     {
//         RenderParams rp = new RenderParams(material);
//         rp.worldBounds = new Bounds(Vector3.zero, 10000*Vector3.one); // use tighter bounds
//         rp.matProps = new MaterialPropertyBlock();
//         rp.matProps.SetBuffer("_Triangles", meshTriangles);
//         rp.matProps.SetBuffer("_Positions", meshPositions);
//         rp.matProps.SetInt("_StartIndex", (int)mesh.GetIndexStart(0));
//         rp.matProps.SetInt("_BaseVertexIndex", (int)mesh.GetBaseVertex(0));
//         rp.matProps.SetMatrix("_ObjectToWorld", Matrix4x4.Translate(new Vector3(-4.5f, 0, 0)));
//         rp.matProps.SetFloat("_NumInstances", 10.0f);
//         Graphics.RenderPrimitives(rp, MeshTopology.Triangles, (int)mesh.GetIndexCount(0), 10);
//     }
// }
