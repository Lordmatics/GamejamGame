using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementState
{
    void UpdateState();

    void TransitionCondition(Collider other);

    void ToGroundMovementState();

    void ToAirMovementState();

    void ToClimbingMovementState();
}
