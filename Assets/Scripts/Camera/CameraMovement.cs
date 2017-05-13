using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField]
    private float speedHorizontal = 2.0f;

    [SerializeField]
    private float speedVertical = 2.0f;

    [SerializeField]
    private float yaw = 0.0f;

    [SerializeField]
    private float pitch = 0.0f;

    [SerializeField]
    private bool bTest = false;

	void Update ()
    {
        if(bTest)
            CameraRotation();
	}

    void CameraRotation()
    {
        yaw += Input.GetAxis("Mouse X") * speedHorizontal;
        pitch -= Input.GetAxis("Mouse Y") * speedVertical;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
