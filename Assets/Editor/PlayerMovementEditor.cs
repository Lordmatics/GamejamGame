using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(PlayerMovement))]
public class PlayerMovementEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("Player Movement Script - Handles only the movement logic", MessageType.Info);

        base.OnInspectorGUI();


        //PlayerMovement testScript = (PlayerMovement)target;
        //if (GUILayout.Button("Build Object"))
        //{
        //    testScript.BuildObject();
        //}
    }
}
