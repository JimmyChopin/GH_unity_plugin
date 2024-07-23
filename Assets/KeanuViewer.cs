using UnityEngine;
using Unity.Collections;
using UnityEditor;
using System;
[AddComponentMenu("Keanu/KeanuViewer")]
[ExecuteInEditMode]
public class KeanuViewer : MonoBehaviour
{
  GameObject refreshTrickObj;
  void Start() {
    Camera.main.gameObject.AddComponent<CameraControll>();

  }
  void OnDestroy() {
    CameraControll cameraController = Camera.main.gameObject.GetComponent<CameraControll>();
    Destroy(cameraController);
  }
  void OnEnable() {

    try{
        DestroyImmediate(GameObject.Find("vert"));
    }catch{}
    EditorApplication.QueuePlayerLoopUpdate();
    refreshTrickObj = new GameObject("vert");
    refreshTrickObj.AddComponent<Vert>();
  }
  void OnDisable()
  {
    DestroyImmediate(refreshTrickObj);

  }
}