using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private TextMeshPro TextMeshPro;
    private float h, s, v;
    public float[] timeToCompleteLevel = new float[2] {00,00};
    public GameManagerScript GameManagerScript;


    // Use this for initialization
    void Start()
    {
        TextMeshPro = GetComponent<TextMeshPro>();
        h = 0.30f; //grün
       // h = 0f; //rot
        s = 1f;
        v = 1f;
        TextMeshPro.color = Color.HSVToRGB(h, s, v);
       
    }

    // Update is called once per frame
    void Update()
    {
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
        if (timeToCompleteLevel[0] == 0)
        {
            h -= 0.0001f;
            if (h > 0)
                TextMeshPro.color = Color.HSVToRGB(h, s, v);
            else
                h = 0;

        }

        TextMeshPro.text = string.Format("{0}:{1:F2}", timeToCompleteLevel[0], timeToCompleteLevel[1]);



    }

}

