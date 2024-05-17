using UnityEngine;
using Unity.Collections;
using UnityEngine.UI;
using UnityEditor;
[AddComponentMenu("Keanu/KeanuViewer")]
[ExecuteAlways]
public class KeanuViewer : MonoBehaviour
{
  GameObject refreshTrickObj;
  void OnEnable() {
    DestroyImmediate(GameObject.Find("Render"));

    EditorApplication.QueuePlayerLoopUpdate();
    refreshTrickObj = new GameObject("Render");
    refreshTrickObj.AddComponent<Render>();
  }
  void OnDisable()
  {

    DestroyImmediate(refreshTrickObj);

  }
}