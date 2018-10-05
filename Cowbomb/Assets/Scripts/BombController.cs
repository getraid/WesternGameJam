using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private TextMeshPro TextMeshPro;
    private float h, s, v;
    public float[] timeToCompleteLevel = new float[2] {00,00};

    // Use this for initialization
    void Start()
    {
        TextMeshPro = GetComponent<TextMeshPro>();
        h = 0.30f; //grün
       // h = 0f; //rot
        s = 1f;
        v = 1f;
        TextMeshPro.color = Color.HSVToRGB(h, s, v);
        h *= 100;
    }

    // Update is called once per frame
    void Update()
    {
        timeToCompleteLevel[1] -= Time.deltaTime;
        if (timeToCompleteLevel[1] <= 0)
        {
            if (timeToCompleteLevel[0] <= 0)
            {
                //ende gelände
                timeToCompleteLevel[0] = 0;
                timeToCompleteLevel[1] = 0;
            }
            else if(timeToCompleteLevel[0] != 0)
            {
                timeToCompleteLevel[1] = 60f;
                timeToCompleteLevel[0] -= 1;
            }
            else
            {
                timeToCompleteLevel[0] -= 1;
            }
        }
        TextMeshPro.text = string.Format("{0}:{1:F2}", timeToCompleteLevel[0], timeToCompleteLevel[1]);



    }

}

