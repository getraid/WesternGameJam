using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour 
{
	//Variables
	public GameManagerScript gameManager;

	//Win Game
	void OnTriggerEnter()
	{
		gameManager.Win ();
	}
}
