using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{

    // Clears an objects tranform back to defaults
    public static void ResetTransformations(this Transform trans)
    {
        trans.position = Vector3.zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale = new Vector3(1, 1, 1);
    }

}
