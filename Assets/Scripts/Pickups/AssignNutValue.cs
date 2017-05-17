using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Scripts/Pickups/AssignNutValue")]
public class AssignNutValue : MonoBehaviour {

    [SerializeField][Header("Array of colours to match with gems")]
    private Material[] colours;

    [SerializeField][Header("Higher = worth more")][Range(0,9)]
    private int nutValue;

    private MeshRenderer nutMesh;

    void Awake()
    {
        nutMesh = GetComponentInChildren<MeshRenderer>();
    }

	// Use this for initialization
	void Start ()
    {
        ChangeColour();
    }

    public void ChangeColour()
    {
        nutMesh = GetComponentInChildren<MeshRenderer>();

        if (nutMesh == null) return;
        if (nutValue >= colours.Length) nutValue = colours.Length;
        nutMesh.material = colours[nutValue];
    }
}
