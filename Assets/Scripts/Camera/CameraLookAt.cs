using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Camera/CameraLookAt")]
public class CameraLookAt : MonoBehaviour
{

    
    public Transform lookAtTarget;

    public float dampener = 6.0f;

    public bool bSmooth = true;


    public bool bTestA = false;

    public bool bTestB = true;

    void LateUpdate()
    {
        if(lookAtTarget)
        {
            if(bSmooth)
            {
                Vector3 direction = lookAtTarget.position - transform.position;
                Quaternion targetRot = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * dampener);
            }
            else
            {
                transform.LookAt(lookAtTarget);
            }
        }
    }
}
