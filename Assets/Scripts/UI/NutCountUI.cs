using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Scripts/UI/NutCountUI")]
public class NutCountUI : MonoBehaviour
{

    private static Text nutCountText;
    public static int nutCount = 0;
     
	void Start ()
    {
        nutCountText = GetComponent<Text>();
        UpdateNuts();
    }

    public static void UpdateNuts()
    {
        nutCountText.text = "Nuts: " + nutCount.ToString("00");
    }

    public static void GainNut()
    {
        nutCount++;
        UpdateNuts();
    }

}
