using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Player/StateMachine/MovementStateMachine")]
public class MovementStateMachine : MonoBehaviour
{

    [HideInInspector]
    public IMovementState currentState;

    [HideInInspector]
    public IMovementState groundState;

    [HideInInspector]
    public IMovementState airState;

    [HideInInspector]
    public IMovementState climbingState;

    void Awake()
    {
        groundState = new GroundMovement(this);
        airState = new AirMovement(this);
        climbingState = new ClimbingMovement(this);
    }

    void Start ()
    {
        currentState = groundState;	
	}
	
	void Update ()
    {
        currentState.UpdateState();
	}

    private void OnCollisionEnter(Collision other)
    {
        // In case transition condition was a solid object not a trigger
        //Debug.Log("CollisionEnter" + other.collider.name);
        currentState.TransitionCondition(other.collider);

    }
    private void OnTriggerEnter(Collider other)
    {
        // if Other tag == floor
        // if Other tag == climb
        // else air
        currentState.TransitionCondition(other);
    }

    // Event to initiate air controls
    // Bound in Player Script
    public void OnJumped()
    {
        currentState.ToAirMovementState();
        Debug.Log("MSM : OnJumped");
    }
}
