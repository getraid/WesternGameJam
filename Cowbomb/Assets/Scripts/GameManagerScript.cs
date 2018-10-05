using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

	//Variables
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
			Debug.Log ("Won");
		}
	}

	//Loose Game
    public void Loose()
    {
        if (!gameLost)
        {
            gameLost = true;
            loosingScreen.SetActive(true);
        }

    }
}
