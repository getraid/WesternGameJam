using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	//Component References
	public Camera playerCamera;
	Rigidbody myRigidbody;

	//Movement Variables
	public float moveSpeed;
	public float gravity;
	public float jumpforce;

	//Initialization
	void Start()
	{
		myRigidbody = GetComponent<Rigidbody>();
	}

	//Fixed Update
	void FixedUpdate() 
	{
		Movement();	
	}

	//Movement
	void Movement()
	{
		//myRigidbody.MovePosition(transform.right * 
	}
}
