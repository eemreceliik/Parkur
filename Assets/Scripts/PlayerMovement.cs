using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   // Movement
    private CharacterController controller;
    public float speed = 1f;

    //Camera Controller
    private float xRotation = 0f;
    public float mouseSensitivity = 100f;

    // Jump and Gravity
    private Vector3 velocity;
    private float gravity = -9.81f;
    private bool ÝsGround;

    public Transform groundChecker;
    public float groundCheckerRadius;
    public LayerMask obstacleLayer;

    public float jumpHeight = 0.1f;
    public float GravityDivide = 100f;
    public float JumpSpeed = 100;
    private float aTimer;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        //Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Check Character is Grounded
        ÝsGround = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, obstacleLayer);


        //Movement
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;

        controller.Move(moveVelocity);

        //Camera Controller
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //Jump and Gravity

        if (!ÝsGround)
        {
            velocity.y += gravity * Time.deltaTime / GravityDivide;
            aTimer += Time.deltaTime / 2;
            speed = Mathf.Lerp(10, JumpSpeed, aTimer);
        }
        else
        {
            velocity.y = -0.05f;
            speed = 10;
            aTimer = 0;
        }

        if(Input.GetKeyDown(KeyCode.Space) && ÝsGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity / GravityDivide);

        }

        controller.Move(velocity);


    }

}
