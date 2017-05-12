using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This Player Class acts as a container for its components", MessageType.Info);

        //base.OnInspectorGUI();
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("Controls", MessageType.Info);
        EditorGUILayout.HelpBox("WASD - Movement", MessageType.Info);
        EditorGUILayout.HelpBox("Space - Jump", MessageType.Info);
        EditorGUILayout.HelpBox("Hold Space in mid air - Glide", MessageType.Info);
    }
}
