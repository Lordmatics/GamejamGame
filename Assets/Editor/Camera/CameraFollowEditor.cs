using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraFollow))]
public class CameraFollowEditor : Editor
{

    public override void OnInspectorGUI()
    {

        EditorGUILayout.HelpBox("This script extracts the target from CameraLookAt to follow", MessageType.Info);
        base.OnInspectorGUI();
    }
}
