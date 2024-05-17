using UnityEngine;
using Unity.Collections;
using UnityEngine.UI;
using UnityEditor;

[ExecuteAlways]
public class Render : MonoBehaviour
{
  
  public Texture texture;
  GraphicsBuffer vertBuffer;
  GraphicsBuffer dataBuffer;
  RenderParams rp;

  // void OnEnable() {
  //   EditorApplication.QueuePlayerLoopUpdate();
  //   refreshTrickObj = new GameObject("hello");
  //   Debug.Log( GameObject.Find("hello"));
  // }

  void Start()
  {
    Shader shader = Shader.Find("shader");
    Material material = new Material(shader);
    //https://docs.unity3d.com/ScriptReference/Shader.PropertyToID.html  && https://forum.unity.com/threads/propertytoid-multiple-shaders.662770/
    int mainTexID = Shader.PropertyToID("_MainTex");
    material.SetTexture(mainTexID, texture);
    rp = new RenderParams(material);
    rp.worldBounds = new Bounds(Vector3.zero, 1000 * Vector3.one); // use tighter bounds
    rp.matProps = new MaterialPropertyBlock();
    GenerateQuadBuffers(12.0f);

  }
  void OnDestroy()
  {
    vertBuffer?.Dispose();
    dataBuffer?.Dispose();
    vertBuffer = null;
    dataBuffer = null;
  }

  // Update is called once per frame
  void Update()
  {
      Graphics.RenderPrimitives(rp, MeshTopology.Triangles, (int)6, 3);
  }

  void GenerateQuadBuffers(float cellSize)
  {    

    vertBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, 6, 2 * sizeof(float));
    // unity use cw winding order
    NativeArray<float> bufferArray = new NativeArray<float>(12, Allocator.Temp)
    {
      [0] = 0, [1] = 1,
      [2] = 1, [3] = 1,
      [4] = 1, [5] = 0,
      [6] = 1, [7] = 0,
      [8] = 0, [9] = 0,
      [10] = 0, [11] = 1,
    };

    vertBuffer.SetData(bufferArray);

    dataBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, 3, 2 * sizeof(float));
    NativeArray<float> dataBufferArr = new NativeArray<float>(length: 6, Allocator.Temp)
    {
      [0] = 0,      [1] = 0,//col, row
      [2] = 1,      [3] = 0,
      [4] = 1,      [5] = 1,

    };

    dataBuffer.SetData(dataBufferArr);
    rp.matProps.SetBuffer("verticeBuff", vertBuffer);
    rp.matProps.SetBuffer("gridIndexBuff", dataBuffer);
    rp.matProps.SetFloat("uCellSize", cellSize);
  }
  

}
