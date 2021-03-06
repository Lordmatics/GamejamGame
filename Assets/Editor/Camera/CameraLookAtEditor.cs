﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraLookAt))]
public class CameraLookAtEditor : Editor
{
    string myMessage;
    MessageType myType;
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        //myMessage = "Finds a Transform for the camera to focus";
        EditorGUILayout.HelpBox(myMessage, myType);
        //EditorGUILayout.LabelField("Test Bool");
        CameraLookAt script = (CameraLookAt)target;

        script.lookAtTarget = (Transform)EditorGUILayout.ObjectField("Look At Transform", script.lookAtTarget, typeof(Transform), true);

        EditorGUILayout.BeginToggleGroup("Requires a target", script.lookAtTarget);
        script.bSmooth = EditorGUILayout.Toggle("Use Smoothing", script.bSmooth);
        script.dampener = EditorGUILayout.FloatField("Slerp Speed", script.dampener);
        EditorGUILayout.EndToggleGroup();

        if(GUILayout.Button("LookAtPlayer"))
        {
            script.LocatePlayer();
        }
        if(script.lookAtTarget != null)
        {
            myMessage = "Camera will look at " + script.lookAtTarget.name;
            myType = MessageType.Info;
            if (GUILayout.Button("Clear Transform"))
            {
                script.lookAtTarget = null;
            }
        }
        else
        {
            myMessage = "Camera has no target... Send help";
            myType = MessageType.Error;
        }
    }
}
