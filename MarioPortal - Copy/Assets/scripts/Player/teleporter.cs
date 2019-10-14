using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        thePlayer.transform.position = teleportTarget.transform.position;      //when the player collides with the game object they player will teleport to another game object
    }
}

    


