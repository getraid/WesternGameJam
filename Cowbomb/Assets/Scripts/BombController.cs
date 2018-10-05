using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BombController : MonoBehaviour
{
	//Variables
    private TextMeshPro TextMeshPro;
	public GameManagerScript GameManagerScript;
    public float[] timeToCompleteLevel = new float[2] {00,00};
	private float hue, sat, val;

    // Use this for initialization
    void Start()
    {
        TextMeshPro = GetComponent<TextMeshPro>();
        hue = 0.30f; //green
        //hue = 0f; //red
        sat = 1f;
        val = 1f;
        TextMeshPro.color = Color.HSVToRGB(hue, sat, val);
       
    }

    // Update is called once per frame
    void Update()
    {
		//Decrease timer
        timeToCompleteLevel[1] -= Time.deltaTime;
        if (timeToCompleteLevel[1] <= 0)
        {
            if (timeToCompleteLevel[0] <= 0)
            {
                GameManagerScript.Loose();
                timeToCompleteLevel[0] = 0;
                timeToCompleteLevel[1] = 0;
            }
            else if(timeToCompleteLevel[0] != 0)
            {
                timeToCompleteLevel[1] = 60f;
                timeToCompleteLevel[0] -= 1;
            }
        }
        
		//Change the color of the timer
		if (timeToCompleteLevel[0] == 0)
        {
            hue -= 0.0001f;
            if (hue > 0)
                TextMeshPro.color = Color.HSVToRGB(hue, sat, val);
            else
                hue = 0;
        }

		//Set the text for the timer
        TextMeshPro.text = string.Format("{0}:{1:F2}", timeToCompleteLevel[0], timeToCompleteLevel[1]);
    }

}

