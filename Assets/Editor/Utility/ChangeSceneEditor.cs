using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ChangeSceneEditor : Editor
{

    [MenuItem("OpenScene/DevScenes/Niall_Scene")]
    public static void OpenNiallScene()
    {
        OpenScene("NiallScene");
    }

    [MenuItem("OpenScene/DevScenes/Ash_Scene")]
    public static void OpenAshScene()
    {
        OpenScene("AshScene");
    }

    [MenuItem("OpenScene/DevScenes/Jamie_Scene")]
    public static void OpenJamieScene()
    {
        OpenScene("JamieScene");
    }

    [MenuItem("OpenScene/DevScenes/Kris_Scene")]
    public static void OpenKrisScene()
    {
        OpenScene("KrisScene");
    }

    [MenuItem("OpenScene/DevScenes/Test_Scene")]
    public static void OpenTestScene()
    {
        OpenScene("TestScene");
    }

    static void OpenScene(string name)
    {
        if(EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene("Assets/Scenes/DevScenes/" + name + ".unity");
        }
    }
}
