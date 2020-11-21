using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerController;

    private float movementSpeed = 5f;
    private float sprint = 12f;
    private float gravity = -19.62f;

    Vector3 verticalVelocity;

    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    void Update()
    {
        CheckGrounded();
        Run();
       
        //movement
        float moveX = Input.GetAxis(Axis.HORIZONTAL);
        float moveZ = Input.GetAxis(Axis.VERTICAL);

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        playerController.Move(move * movementSpeed * Time.deltaTime);

        verticalVelocity.y += gravity * Time.deltaTime;

        playerController.Move(verticalVelocity);
    }

    //is the player on the ground
    void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && verticalVelocity.y < 0)
        {
            verticalVelocity.y = -2f;
        }
    }

    //sprtint function
    void Run()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = 5f;
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = sprint;
        }
    }
}
