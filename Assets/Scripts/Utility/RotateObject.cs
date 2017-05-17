using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Utility/RotateObject")]
public class RotateObject : MonoBehaviour
{

    public float rotationSpeed = 75.0f;

    private bool chance;
    void Start()
    {
        DetermineDirection();
    }

    void DetermineDirection()
    {
        chance = Random.Range(0, 2) == 0 ? chance = true : chance = false;
    }

    void DoRotation()
    {
        switch(chance)
        {
            case true:
                transform.Rotate(new Vector3(0.25f, 1.0f, 0.0f), Time.deltaTime * rotationSpeed);
                break;
            case false:
                transform.Rotate(new Vector3(0.0f, 1.0f, 0.25f), Time.deltaTime * rotationSpeed);
                break;
        }
    }

    void Update()
    {
        DoRotation();
    }
}
