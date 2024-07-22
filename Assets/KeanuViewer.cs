using UnityEngine;
using Unity.Collections;
using UnityEditor;
using System;
[AddComponentMenu("Keanu/KeanuViewer")]
// [ExecuteInEditMode]
public class KeanuViewer : MonoBehaviour
{
  GameObject refreshTrickObj;
  GameObject viewControlObj;

  void OnEnable() {
    try{
        DestroyImmediate(GameObject.Find("vert"));
    }catch{}
    EditorApplication.QueuePlayerLoopUpdate();
    refreshTrickObj = new GameObject("vert");
    refreshTrickObj.AddComponent<Vert>();
    viewControlObj = new GameObject("viewControl");
    viewControlObj.AddComponent<CameraDrag>();
  }
  void OnDisable()
  {
    DestroyImmediate(refreshTrickObj);

  }
}