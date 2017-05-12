using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : IMovementState
{
    private readonly MovementStateMachine movementStateMachine;

    public GroundMovement(MovementStateMachine MSM)
    {
        movementStateMachine = MSM;
    }

    public void UpdateState()
    {
        Debug.Log("Updating Ground State");
        // Do ground movement functionality
        Player.instance.ToGroundState();
    }

    public void TransitionCondition(Collider other)
    {
        Debug.Log("Ground Transition Collider from: " + other.gameObject.name);
        if(other.gameObject.CompareTag("Ground"))
        {
            ToGroundMovementState();
        }
        else if(other.gameObject.CompareTag("Climb"))
        {
            ToClimbingMovementState();
        }
    }

    public void ToGroundMovementState()
    {
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
