using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BombController : MonoBehaviour
{
    //Variables
    public GameManagerScript GameManagerScript;
    public TextMeshPro TextMeshPro;

    // Set Minutes and Seconds for Bomb here
    public float timeMinutes = 01;
    public float timeSeconds = 00;
    
    //colorhue for
    private float hue, sat, val;

    // Use this for initialization
    void Start()
    {
        hue = 0.30f; //green
        sat = 1f;
        val = 1f;
        TextMeshPro.color = Color.HSVToRGB(hue, sat, val);

    }

    // Update is called once per frame
    void Update()
    {
        //Decrease timer
        timeSeconds -= Time.deltaTime;
        if (timeSeconds <= 0)
        {
            if (timeMinutes <= 0)
            {
                GameManagerScript.Loose();
                timeMinutes = 0;
                timeSeconds = 0;
            }
            else if (timeMinutes != 0)
            {
                timeSeconds = 60f;
                timeMinutes -= 1;
            }
        }

        //Change the color of the timer
        if (timeMinutes == 0)
        {
            hue -= 0.0001f;
            if (hue > 0)
                TextMeshPro.color = Color.HSVToRGB(hue, sat, val);
            else
                hue = 0;
        }

        //Set the text for the timer
        TextMeshPro.text = string.Format("{0}:{1:F2}", timeMinutes, timeSeconds);
    }

}

