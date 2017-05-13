using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AssignNutValue))]
public class AssignNutValueEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("Each number corresponds to a gem colour - higher number == higher value", MessageType.Info);

        EditorGUILayout.HelpBox("This script needs to be tagged Pickup, for anything to work", MessageType.Warning);


        base.OnInspectorGUI();

        AssignNutValue myScript = (AssignNutValue)target;
        if (GUILayout.Button("Change Colour"))
        {
            myScript.ChangeColour();
        }
    }
}
