using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RotateObject))]
public class RotateObjectEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This class Simply rotates whatever its attached to", MessageType.Info);

        base.OnInspectorGUI();
    }
}
