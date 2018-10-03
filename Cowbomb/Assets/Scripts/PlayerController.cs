﻿using System.Collections;
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

	//Mouselook Variables
	private float yaw;
	private float pitch;
	private CursorLockMode cursor_state = CursorLockMode.Locked;
	public float mouse_sensitivity;

	//Initialization
	void Start()
	{
		Cursor.lockState = cursor_state;
		myRigidbody = GetComponent<Rigidbody>();
		yaw = transform.eulerAngles.y;
		pitch = transform.eulerAngles.x;
	}

	//Fixed Update
	void FixedUpdate() 
	{
		//Movement();	

		if (CheckGrounded())
			myRigidbody.velocity = Vector3.zero;
	}

	//Update
	void Update()
	{
		Movement();
		Mouselook();
		Jumping();
	}

	//Movement
	void Movement()
	{
		myRigidbody.MovePosition (transform.position + transform.right * Input.GetAxis ("Horizontal") 
			* moveSpeed * Time.deltaTime + transform.forward * Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime);
	}

	//Jumping
	void Jumping()
	{
		if (Input.GetKeyDown(KeyCode.Space) && CheckGrounded())
		{
			myRigidbody.AddForce(Vector3.up * jumpforce);
		}
	}

	//Mouse-Look
	void Mouselook()
	{
		yaw += Input.GetAxis("Mouse X") * mouse_sensitivity;
		pitch -= Input.GetAxis("Mouse Y") * mouse_sensitivity;
		pitch = Mathf.Clamp (pitch, -89.99f, 89.99f);

		myRigidbody.MoveRotation(Quaternion.Euler(new Vector3(myRigidbody.transform.eulerAngles.x, yaw, myRigidbody.transform.eulerAngles.z)));
		playerCamera.transform.eulerAngles = new Vector3(pitch, playerCamera.transform.eulerAngles.y, playerCamera.transform.eulerAngles.z);
	}

	//Check if grounded
	bool CheckGrounded()
	{
		Vector3 startPoint = transform.position;
		return Physics.Raycast (startPoint, Vector3.down, 1);
	}
}
