using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Player/PlayerPickup")]
public class PlayerPickup : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
    {
        // Overlap was a pickup
        if(other.gameObject.CompareTag("Pickup"))
        {
            // Logic
            MoveToPlayer movementScript = other.gameObject.GetComponent<MoveToPlayer>();
            if(movementScript != null)
                movementScript.BeginMovement();            
        }
    }
}
