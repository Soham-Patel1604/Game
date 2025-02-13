using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guicam : MonoBehaviour
{
    private void OnGUI()
    {
        //Make a background for button 
        GUI.Box(new Rect(20, 10, 100, 90), "Speed :" + playermovement.speeds);

    }
}
