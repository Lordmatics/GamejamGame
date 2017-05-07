using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NutSpawner))]
public class NutSpawnerEditor : Editor
{


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        NutSpawner myScript = (NutSpawner)target;
        if (GUILayout.Button("Build Object"))
        {
            myScript.BuildObject();
        }

        //if (GUILayout.Button("Destroy All Objects Spawned"))
        //{
        //    myScript.ClearObjectsSpawned();
        //}
    }
}
