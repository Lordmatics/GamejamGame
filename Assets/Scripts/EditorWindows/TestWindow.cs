using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[AddComponentMenu("Scripts/CustomEditorWindows/TestWindow")]
public class TestWindow : EditorWindow
{

    string myString = "Hello World";

    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;

    // Add menu named "My Window" to the Window menu
    [MenuItem("NiallsMenus/TestWindow")]
    public static void Init()
    {
        // Get existing open window or if none, make a new one:
        TestWindow window = (TestWindow)EditorWindow.GetWindow(typeof(TestWindow));
    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);

        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();

        //block = EditorGUILayout.ObjectField("Object", block, typeof(Object), true);
    }
}
