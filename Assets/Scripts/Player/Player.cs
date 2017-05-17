using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Player/Player")]
public class Player : MonoBehaviour
{

    private PlayerMovement movementScript;

    private MovementStateMachine movementSM;

    public static Player instance;

    // Use this for initialization

    public enum PlayerState { Ground , Air, Climb, Falling };
    public PlayerState currentState = PlayerState.Ground;

    void Awake()
    {
        instance = this;

        movementScript = GetComponentInChildren<PlayerMovement>();

        movementSM = GetComponentInChildren<MovementStateMachine>();
    }

    void Start ()
    {
        movementScript.AssignJumpEvent(movementSM.OnJumped);
    }

    // Update is called once per frame
    void Update ()
    {
        switch(currentState)
        {
            case PlayerState.Ground:
                movementScript.PlayerGroundControls();
                movementScript.PlayerJump();
                break;
            case PlayerState.Air:
                movementScript.PlayerGlide();
                break;
            
            case PlayerState.Climb:
                movementScript.PlayerClimbControls();
                break;
            case PlayerState.Falling:
                break;
        }
        //movementScript.PlayerJump();
	}

    public void ToGroundState()
    {
        currentState = PlayerState.Ground;
    }

    public void ToAirState()
    {
        currentState = PlayerState.Air;
    }

    public void ToClimbState()
    {
        currentState = PlayerState.Climb;
    }

    public void ToFallingState()
    {
        currentState = PlayerState.Falling;
    }

    #region PROGRAMMING_KNOWLEDGE
    // Design Patterns 

    // Strategy Pattern
    // Singleton Pattern
    // Factory Pattern
    // Observer Pattern

    // Design Principles - SOLID
    // Single Responsibilty Principle - SRP - Each class should only do one thing
    // Open Closed Principle - OCP - Classes/Functions should be open for extension but closed for modification
    // Liskovs Substitution Principle - LSP - child classes must be substitutable with its base class - Bannana* ban = new Fruit()
    // Interface Segregation Principle - ISP - clients should not be forced to depend on methods they dont use
    // Dependancy Inversion Principle - DIP - high level stuff should not depend on low level modules - abstractions should not depend on details.
    #endregion


}
