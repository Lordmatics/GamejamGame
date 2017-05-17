using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraLookAt))]
[AddComponentMenu("Scripts/Camera/CameraFollow")]
public class CameraFollow : MonoBehaviour
{

    private Transform lookAtTarget;

    [SerializeField]
    private float distance = 10.0f;

    [SerializeField][Range(0.0f,10.0f)]
    private float heightOffset = 5.0f;

    [Header("This needs to be above 50, when gliding, to prevent camera glitch")]
    public float rateOfHeightChangeSpeed = 50.0f;

    [SerializeField]
    private float cameraCatchupSpeed = 10.0f;

	// Use this for initialization
	void Start ()
    {
        CameraLookAt script = GetComponent<CameraLookAt>();
        lookAtTarget = script.lookAtTarget;	
	}
	
    void LateUpdate()
    {
        if (!lookAtTarget) return;

        // Calculate the current rotation angles
        float wantedRotationAngle = lookAtTarget.eulerAngles.y;
        float wantedHeight = lookAtTarget.position.y + heightOffset;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, cameraCatchupSpeed * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, rateOfHeightChangeSpeed * Time.deltaTime);

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = lookAtTarget.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        // Set the height of the camera
        CartesianCoordinates coOrdinates = new CartesianCoordinates();
        coOrdinates.y = currentHeight;
        transform.EditTransform(coOrdinates, false, true);

        // Always look at the target
        transform.LookAt(lookAtTarget);
    }
}
