using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ss : MonoBehaviour
{
    public GameObject go; 
    private Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter mf= go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr= go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        Mesh m = new Mesh();
        m.vertices = new Vector3[]{
            new Vector3(0,0,0),
            new Vector3(5,0,0),
            new Vector3(5,5,0),
            new Vector3(0,5,0)
        };
        m.uv = new Vector2[]{
            new Vector3(0,0),
            new Vector3(0,1),
            new Vector3(1,1),
            new Vector3(1,0),
        };
        m.triangles = new int[] {0,1,2, 0, 2,3 };
        mf.mesh = m;
        m.RecalculateBounds();
        m.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
