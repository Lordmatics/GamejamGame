using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerAnimations))]
public class PlayerAnimationsEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This script handles the animation specific events", MessageType.Info);

        base.OnInspectorGUI();
    }
}
