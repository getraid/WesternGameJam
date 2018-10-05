using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    //Variables
    public Rigidbody Player;
    public bool gameWon = false;
    public bool gameLost = false;
    public GameObject winningScreen;
    public GameObject loosingScreen;

    //Win Game
    //TODO: Needs to disable Player Movement
    public void Win()
    {
        if (!gameWon)
        {
            gameWon = true;
            winningScreen.SetActive(true);
            DisableMovement();
            Debug.Log("Won");
        }
    }

    private void DisableMovement()
    {
        Player.velocity = Vector3.zero;
        //disable playermovement after win/loose
    }

    //Loose Game
    public void Loose()
    {
        if (!gameLost && !gameWon)
        {
            gameLost = true;
            DisableMovement();
            loosingScreen.SetActive(true);
        }

    }

    void Update()
    {
        //Restart Level
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

    }

}
