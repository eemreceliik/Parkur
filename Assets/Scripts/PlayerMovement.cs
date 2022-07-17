using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   // Movement
    private CharacterController characterController;
    public float speed = 6f;

    //Camera Controller
    private float xRotation = 0f;
    public float mouseSensitivity = 100f;

    // Jump and Gravity
    private Vector3 moveDirection;

    public float jumpSpeed = 8f;
    public float jumpWait=15;
    public float gravity = 20f;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        //Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {

        //Movement


        if (characterController.isGrounded)
        {
            moveDirection = transform.forward*Input.GetAxis("Vertical") +transform.right*(Input.GetAxis("Horizontal"));
            moveDirection.y = 0;
            moveDirection *= speed;


            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            
        }

        else
        {
            float y = moveDirection.y;
            moveDirection = transform.forward * jumpWait * Input.GetAxis("Vertical") + transform.right* jumpWait * (Input.GetAxis("Horizontal"));
            moveDirection.y = y;
            //moveDirection = new Vector3(jumpWait * Input.GetAxis("Vertical"), moveDirection.y, -jumpWait * Input.GetAxis("Horizontal"));
            //moveDirection *= speed;
        }


        // as an acceleration (ms^-2)
        moveDirection.y -= gravity*Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);



        //Camera Controller
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
       

        


    }


}

