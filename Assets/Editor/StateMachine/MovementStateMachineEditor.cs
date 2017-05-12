using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MovementStateMachine))]
public class MovementStateMachineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("This state machine, handles the various types of movement interactions that occur for the player", MessageType.Info);

        EditorGUILayout.HelpBox("When the player collides with tags Ground or Climb those states will be changed", MessageType.Info);

        EditorGUILayout.HelpBox("When the player presses space to jump, after 1 second, holding space will enter glide mode", MessageType.Info);

        base.OnInspectorGUI();
    }
}
