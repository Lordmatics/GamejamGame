using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingMovement : IMovementState
{

    private readonly MovementStateMachine movementStateMachine;

    public ClimbingMovement(MovementStateMachine MSM)
    {
        movementStateMachine = MSM;
    }

    public void UpdateState()
    {
        Debug.Log("Updating Climbing State");
        // Do climbing movement functionality
        Player.instance.ToClimbState();

    }

    public void TransitionCondition(Collider other)
    {
        Debug.Log("Climb Transition Collider from: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Ground"))
        {
            ToGroundMovementState();
        }
        else if (other.gameObject.CompareTag("Climb"))
        {
            ToClimbingMovementState();
        }
    }

    public void ToGroundMovementState()
    {
        Player.instance.movementScript.ResetRigidbodyVelocities();
        movementStateMachine.currentState = movementStateMachine.groundState;
    }

    public void ToAirMovementState()
    {
        movementStateMachine.currentState = movementStateMachine.airState;
    }

    public void ToClimbingMovementState()
    {
        movementStateMachine.currentState = movementStateMachine.climbingState;
    }
}
