using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsController : MonoBehaviour
{
    public Rigidbody Player;
    public int WhenToResetUp = -300;
    public int WhenToResetDown = -300;
    public float startingHeight = 5;

    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        startPosition = Player.transform.position;
        startPosition.y += startingHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.position.y < WhenToResetDown || Player.position.y > WhenToResetUp)
        {
            Player.transform.position = startPosition;
            Player.velocity = Vector3.zero;
        }
       
    }
}
