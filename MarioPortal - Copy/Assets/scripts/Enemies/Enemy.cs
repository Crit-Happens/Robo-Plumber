using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float distance;
    public Transform groundDetection;

    private bool movingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);       //objects moves on a 2d plan (x and y) in the case it move left and it's times by speed and Time(delta time)                      

        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);   //sends a raycast (dection line) down to a set amount of distance to detect the gound 
        if(groundinfo.collider == false)
        {
            if(movingRight == false)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);        //if the raycast can't detect the ground then the player will rotate 180 degrees on the y axis (basically moving in oppisite direction) vise-versa
                movingRight = true;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;
            }
        }
    }
}
