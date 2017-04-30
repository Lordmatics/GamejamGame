using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    private PlayerMovement movementScript;

	// Use this for initialization
	void Start ()
    {
        movementScript = GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        movementScript.PlayerControls();
        movementScript.PlayerJump();
	}

}
