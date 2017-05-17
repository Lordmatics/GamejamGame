using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraStruct
{
    [Header("Y Offset")]
    public float y;

    [Header("Z Offset")]
    public float z;

    public CameraStruct(float a = 8.0f, float b = 7.0f)
    {
        y = a;
        z = b;
    }
}

[AddComponentMenu("Scripts/Camera/CameraMovement")]
public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private bool bTest = false;

    [SerializeField]
    private float turnSpeed = 4.0f;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Vector3 offsetHorizontal;

    [SerializeField]
    private Vector3 offsetVertical;

    [SerializeField]
    private CameraStruct cameraValues = new CameraStruct(7.0f, 4.5f);

    [SerializeField]
    private string axisHorizontal = "Xbox X";

    [SerializeField]
    private string axisVertical = "Xbox Y";

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        UpdateOffset();
    }

    void LateUpdate()
    {
        if (bTest)
        {
            offsetHorizontal = Quaternion.AngleAxis(Input.GetAxis(axisHorizontal) * turnSpeed, Vector3.up) * offsetHorizontal;
            //offsetVertical = Quaternion.AngleAxis(Input.GetAxis(axisVertical) * turnSpeed, Vector3.right) * offsetVertical;
        }

        transform.position = playerTransform.position + offsetHorizontal;// + offsetVertical;
        transform.LookAt(playerTransform.position);
    }

    public void UpdateOffset()
    {
        offsetHorizontal = new Vector3(playerTransform.position.x, playerTransform.position.y + cameraValues.y, playerTransform.position.z + cameraValues.z);
        //offsetVertical = new Vector3(playerTransform.position.x, playerTransform.position.y + cameraValues.y, playerTransform.position.z + cameraValues.z);

    }
}
