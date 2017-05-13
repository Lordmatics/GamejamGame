using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyCameraTransform : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Transform cameraTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        cameraTransform = Camera.main.transform;
    }

	void Update ()
    {
        transform.position = new Vector3(cameraTransform.position.x, playerTransform.position.y, cameraTransform.position.z);
        transform.LookAt(playerTransform.position);
    }
}
