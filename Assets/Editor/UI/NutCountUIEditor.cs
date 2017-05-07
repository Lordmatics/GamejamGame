using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NutCountUI))]
public class NutCountUIEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("Thsi class simply tracks and updates the nut count", MessageType.Info);

        base.OnInspectorGUI();
    }
}
