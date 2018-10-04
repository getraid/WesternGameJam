using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

	//Variables
	public bool gameWon = false;
	public GameObject winningScreen;

    //Win Game
    //Needs to disable Player Movement
    public void Win()
	{
		if (!gameWon)
		{
			gameWon = true;
			winningScreen.SetActive (true);
			Debug.Log ("Won");
		}
	}
}
