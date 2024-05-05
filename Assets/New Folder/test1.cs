using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
 // 网格渲染器
 MeshRenderer meshRenderer;
 // 网格过滤器
 MeshFilter meshFilter;

 // 用来存放顶点数据
 List<Vector3> verts;        // 顶点列表
 List<int> indices;          // 序号列表

 private void Start()
 {
  verts = new List<Vector3>();
  indices = new List<int>();
  meshRenderer = GetComponent<MeshRenderer>();
  meshFilter = GetComponent<MeshFilter>();
  Generate();
 }

 public void Generate()
 {
  // 把顶点和序号数据填写在列表里
  AddMeshData1();//三角形
  // 用列表数据创建网格Mesh对象
  Mesh mesh = new Mesh();
  mesh.SetVertices(verts);
  //mesh.vertices = verts.ToArray();
  mesh.SetIndices(indices, MeshTopology.Triangles, 0);
  //mesh.triangles = indices.ToArray();
  // 自动计算法线
  mesh.RecalculateNormals();
  // 自动计算物体的整体边界
  mesh.RecalculateBounds();
  // 将mesh对象赋值给网格过滤器，就完成了
  meshFilter.mesh = mesh;
 }
 // 填写顶点和序号列表
 void AddMeshData1()
 {
  verts.Add(new Vector3(0, 0, 0));
  verts.Add(new Vector3(0, 0, 1));
  verts.Add(new Vector3(1, 0, 1));
  indices.Add(0); indices.Add(1); indices.Add(2);
 }
}