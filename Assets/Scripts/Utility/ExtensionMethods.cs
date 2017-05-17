using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartesianCoordinates
{
    public float x;
    public float y;
    public float z;

    public CartesianCoordinates(float i = 0.0f, float j = 0.0f, float k = 0.0f)
    {
        x = i;
        y = j;
        z = k;
    }
}

public class StoredVelocities
{
    public Vector3 vel;
    public Vector3 angVel;

    public StoredVelocities(Vector3 a, Vector3 b)
    {
        vel = a;
        angVel = b;
    }
}
public static class ExtensionMethods
{
    public enum Cartesians { X, Y, Z};

    // Clears an objects tranform back to defaults
    public static void ResetTransformations(this Transform trans)
    {
        trans.position = Vector3.zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale = new Vector3(1, 1, 1);
    }

    public static StoredVelocities ResetVelocity(this Rigidbody _rigid)
    {
        StoredVelocities temp = new StoredVelocities(_rigid.velocity, _rigid.angularVelocity);
        _rigid.velocity = Vector3.zero;
        _rigid.angularVelocity = Vector3.zero;
        return temp;
    }

    public static void ResumeVelocity(this Rigidbody _rigid, StoredVelocities vels)
    {
        _rigid.velocity = vels.vel;
        _rigid.angularVelocity = vels.angVel;
    }

    public static void EditTransform(this Transform trans, CartesianCoordinates coOrd, bool bChangeX = false, bool bChangeY = false, bool bChangeZ = false)
    {
        float tempX = bChangeX ? coOrd.x : trans.position.x;
        float tempY = bChangeY ? coOrd.y : trans.position.y;
        float tempZ = bChangeZ ? coOrd.z : trans.position.z;

        trans.position = new Vector3(tempX, tempY, tempZ);
    }

    public static void ChangeTransform( this Transform trans, int index, float value)
    {
        switch(index)
        {
            case 0:
                trans.position = new Vector3(value, trans.position.y, trans.position.z);
                break;
            case 1:
                trans.position = new Vector3(trans.position.x, value, trans.position.z);
                break;
            case 2:
                trans.position = new Vector3(trans.position.x, trans.position.y, value);
                break;
            default:
                trans.position = new Vector3(value, trans.position.y, trans.position.z);
                break;
        }
    }
}
