using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSpawner : MonoBehaviour
{

    [SerializeField]
    private Vector3 spawnPoint;

    public void BuildObject()
    {
        GameObject spawnedObj = (GameObject)Instantiate(Resources.Load("NutPickup" , typeof(GameObject)), spawnPoint, Quaternion.identity);
        //if (parents.Length > 0)
        //    if (parentIndex < parents.Length)
        //    {
        //        spawnedObj.transform.parent = parents[parentIndex].transform;
        //        spawnedObjects.Add(spawnedObj);
        //    }
    }
}
