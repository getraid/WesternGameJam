using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour 
{
	//Variables
	private Vector3 startPosition;
	private float elapsedFrames = 0;
	public float range;
	public float wobbleSpeed;
	public GameManagerScript gameManager;

	// Use this for initialization
	void Start () 
	{
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		elapsedFrames += 0.1f;
		transform.position = new Vector3 (startPosition.x, startPosition.y + Mathf.Sin (elapsedFrames * wobbleSpeed) * range, startPosition.z);
		transform.Rotate (new Vector3 (0, 1, 0));
	}

	//Win Game
	void OnTriggerEnter()
	{
		gameManager.Win ();
	}
}
