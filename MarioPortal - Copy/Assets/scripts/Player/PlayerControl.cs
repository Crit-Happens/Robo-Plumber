using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    public bool rotationEnabled = true;
    public float rotationSpeed;
    public float gravity;
    public float jumpForce;
    public float checkRadius;
    public Transform groundCheckObj;

    private float currentSpeed;
    private float velocity;
    private bool isGrounded;
    private CharacterController controller;
    Animator anim;

       
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = moveSpeed;                                         //current speed = move speed
        controller = GetComponent<CharacterController>();                 //controller = Character controller         
        anim = GetComponent<Animator>();                                  //amin = aminator
    }

  //Checks if the GameObject is grounded
    void Update()
    {
        if (groundCheckObj.gameObject.activeSelf == true)                                                                                          
        {
            isGrounded = Physics.CheckSphere(groundCheckObj.position, checkRadius, LayerMask.GetMask("Ground"), QueryTriggerInteraction.Ignore);
        }
        Vector3 move = Vector3.zero;
        float v = Input.GetAxis("Vertical") * currentSpeed;
        float h = Input.GetAxis("Horizontal") * currentSpeed;            //Object can move on all 3 axis (up, down, forward, back, left and right) and its = current speed besides the rotation which is equal to rotation speed
        float r = Input.GetAxis("Rotate") * rotationSpeed;


        if (h > 0)
        {
            //play animation move forward
            anim.SetBool("MoveForward", true);
        }
        if (h < 0)
        {
            //play animation move backward
            anim.SetBool("MoveForward", false);
        }

        if (isGrounded == true)
        {
            velocity = -gravity * Time.deltaTime;                          //if the player is grounded they can jump if not they can't jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity = jumpForce;
                if(groundCheckObj.gameObject.activeSelf == true)
                {
                    groundCheckObj.gameObject.SetActive(false);
                }
                isGrounded = false;
            }
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
            if(groundCheckObj.gameObject.activeSelf == false)                 //if the player is not grounded they will fall
            {
                if(velocity < 0)
                {
                    groundCheckObj.gameObject.SetActive(true);
                }
            }
        }

        ApplyMovement(move, velocity, v, h, r);
    }
    //this block of code stats the players move on the x, y and z axis and its calculated by current speed and time(delta time)
    void ApplyMovement(Vector3  position, float velocity, float vertical, float horizontal, float angle)
    {
        if(rotationEnabled == true)
        {
            Vector3 rot = transform.eulerAngles;                                                 
            rot.y += angle * Time.deltaTime;
            transform.eulerAngles = rot;
        }

        position += transform.forward * vertical * currentSpeed * Time.deltaTime;
        position += transform.right * horizontal * currentSpeed * Time.deltaTime;
        position.y += velocity * Time.deltaTime;
        controller.Move(position);
    }

    private void OnDrawGizmos()
    {
        Color color = Color.red;
        Gizmos.color = color;                                         //the ground checkobject is set to a sphere and the colour red
        Gizmos.DrawSphere(groundCheckObj.position, checkRadius);
    }
}
