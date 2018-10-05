using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Component References
    public Camera playerCamera;
    private Rigidbody myRigidbody;
    private CapsuleCollider myCapsuleCollider;

    //Movement Variables
    public float moveSpeed;
    public float gravity;
    public float jumpforce;
    public float raycastMaxDistance = 0.21f;
    public bool isMoving;
    public float speedMultiplier;

    //Mouselook Variables
    private float yaw;
    private float pitch;
    private CursorLockMode cursor_state = CursorLockMode.Locked;
    public float mouse_sensitivity;

    //Animation Variables
    private Animator myAnimator;


    // Initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider>();

        Cursor.lockState = cursor_state;
        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
    }


    // Fixed Update method
    void FixedUpdate()
    {
        bool grounded = CheckGroundedCapsulecast();
        if (grounded)
            myRigidbody.velocity = Vector3.zero;
        myAnimator.SetBool("IsJumping", !grounded);
    }


    // Update method
    void Update()
    {
        Movement();
        CheckIfMoving();
        Mouselook();
        Jumping();
    }


    // MovementMethod
    private void Movement()
    {
        float temp = moveSpeed;
        CheckSprintButton();
        myRigidbody.MovePosition(transform.position + transform.right * Input.GetAxis("Horizontal")
            * moveSpeed * Time.deltaTime + transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        moveSpeed = temp;
    }


    // Used for moving animation
    private void CheckIfMoving()
    {
        isMoving = Mathf.Abs(Input.GetAxis("Horizontal")) > 0 || Mathf.Abs(Input.GetAxis("Vertical")) > 0;
        myAnimator.SetBool("IsMoving", isMoving);
    }


    // Checks if sprint button "Sprint" is pressed, if so, applies a given speed multiplier.
    private void CheckSprintButton()
    {
        if (Input.GetButton("Sprint"))
        {
            moveSpeed *= speedMultiplier;
            myAnimator.SetFloat("SpeedUp", speedMultiplier);
        }
        else
        {
            myAnimator.SetFloat("SpeedUp", 1);
        }
    }


    // Jump method
    private void Jumping()
    {
        if (Input.GetButtonDown("Jump") && CheckGroundedCapsulecast())
        {
            myRigidbody.AddForce(Vector3.up * jumpforce);
        }
    }


    // Mouselook method
    private void Mouselook()
    {
        yaw += Input.GetAxis("Mouse X") * mouse_sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouse_sensitivity;
        pitch = Mathf.Clamp(pitch, -89.99f, 49.99f);

        myRigidbody.transform.eulerAngles = new Vector3(myRigidbody.transform.eulerAngles.x, yaw, myRigidbody.transform.eulerAngles.z);
        playerCamera.transform.eulerAngles = new Vector3(pitch, yaw, playerCamera.transform.eulerAngles.z);
    }

    //Check if grounded by checking if capsule is in
    private bool CheckGroundedCapsulecast()
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.red, 2f);
        return Physics.CapsuleCast(transform.position, transform.position, myCapsuleCollider.radius, Vector3.down, raycastMaxDistance);
    }

    [Obsolete]
    private bool CheckGroundedRaycast()
    {
        return Physics.Raycast(transform.position, Vector3.down, raycastMaxDistance);
    }

}

