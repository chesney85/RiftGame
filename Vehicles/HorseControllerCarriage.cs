using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseControllerCarriage : MonoBehaviour
{



    [Header("Rotation")] public float horizontalSpeed = 2.0F;




    [Header("Movement")] private float speed = 6.0F;

    public float walkSpeed;
    public float runSpeed;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    public Animator horse1;
    public Animator horse2;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetButton("Oculus_CrossPlatform_PrimaryThumbstick"))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        if (Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") > 0.1f)
        {
            if (Input.GetButton("Oculus_CrossPlatform_PrimaryThumbstick"))
            {
                //play run animation
                horse1.Play("run");
                horse2.Play("run");
            }
            else
            {
                //play walk animation
                horse1.Play("walk");
                horse2.Play("walk");
            }

        }

        if (Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") < 0.1f)
        {
            //play idle animation
            horse1.Play("idle");
            horse2.Play("idle");
        }



        // is the controller on the ground?
        if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(0, 0, Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            moveDirection *= speed;


        }

        float h = horizontalSpeed * Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal");
//        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);


        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;

        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);
    }
}
