using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraLookAt))]
public class CameraLookAtEditor : Editor
{

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        //EditorGUILayout.LabelField("Test Bool");
        CameraLookAt script = (CameraLookAt)target;

        script.lookAtTarget = (Transform)EditorGUILayout.ObjectField("Look At Transform", script.lookAtTarget, typeof(Transform), true);

        EditorGUILayout.BeginToggleGroup("Requires a target", script.lookAtTarget);
        script.bSmooth = EditorGUILayout.Toggle("Use Smoothing", script.bSmooth);
        script.dampener = EditorGUILayout.FloatField("Slerp Speed", script.dampener);
        EditorGUILayout.EndToggleGroup();

        if (GUILayout.Button("Clear Transform"))
        {
            script.lookAtTarget = null;
        }
    }
}
