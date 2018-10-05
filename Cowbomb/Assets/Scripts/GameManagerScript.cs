using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

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
			winningScreen.SetActive (true);
            DisableMovement();
			Debug.Log ("Won");
		}
	}

    private void DisableMovement()
    {
      Player.velocity = Vector3.zero;
   //   Player.gameObject.SetActive(false);
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
}
