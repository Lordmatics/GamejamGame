using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMovement : IMovementState
{

    private readonly MovementStateMachine movementStateMachine;

    public AirMovement(MovementStateMachine MSM)
    {
        movementStateMachine = MSM;
    }

    public void UpdateState()
    {
        // Do Air movement functionality
        Player.instance.ToAirState();
    }

    public void TransitionCondition(Collider other)
    {
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
