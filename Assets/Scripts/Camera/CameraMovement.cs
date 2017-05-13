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
public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private bool bTest = false;

    [SerializeField]
    private float turnSpeed = 4.0f;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private CameraStruct cameraValues = new CameraStruct(7.0f, 4.5f);

    [SerializeField]
    private string axis = "Xbox X";

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        UpdateOffset();
    }

    void LateUpdate()
    {
        if (bTest)
        {
            offset = Quaternion.AngleAxis(Input.GetAxis(axis) * turnSpeed, Vector3.up) * offset;
        }

        transform.position = playerTransform.position + offset;
        transform.LookAt(playerTransform.position);
    }

    public void UpdateOffset()
    {
        offset = new Vector3(playerTransform.position.x, playerTransform.position.y + cameraValues.y, playerTransform.position.z + cameraValues.z);

    }
}
