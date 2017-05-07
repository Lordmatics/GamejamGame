using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MoveToPlayer))]
public class MoveToPlayerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This class handles pushing the pickup into the player", MessageType.Info);

        base.OnInspectorGUI();

    }
}
