using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CopyCameraTransform))]
public class CopyCameraTransformEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("Utility Script to isolate the players y co-ordinate from the cameras transform, to map the movement proportions, leading to a decoupled system", MessageType.Info);

        EditorGUILayout.HelpBox("This object must be tagged - RotationTransform, for this to work", MessageType.Warning);


        base.OnInspectorGUI();
    }
}
