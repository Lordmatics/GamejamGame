using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraMovement))]
public class CameraMovementEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("Controls for the camera movement", MessageType.Info);

        base.OnInspectorGUI();
    }

}
