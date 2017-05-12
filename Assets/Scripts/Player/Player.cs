using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private PlayerMovement movementScript;

	// Use this for initialization
	void Start ()
    {
        movementScript = GetComponentInChildren<PlayerMovement>();
    }

	// Update is called once per frame
	void Update ()
    {
        movementScript.PlayerControls();
        movementScript.PlayerJump();
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
