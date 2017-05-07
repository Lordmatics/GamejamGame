using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerPickup))]
public class PlayerPickupEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This class checks for overlaps", MessageType.Info);

        base.OnInspectorGUI();
    }
}
