using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public bool lookAtTarget;
    public bool localPosition;
    public Transform target;
    public Vector3 roationLock;
    public Vector3 posOffset;
    
    // Update is called once per frame
    void Update()
    {
        if(localPosition == true)                               
        {
            transform.position = target.position + posOffset;       //if local position is ticked the camera will be set to players location
        }

        if (lookAtTarget == true)
        {
            transform.LookAt(target);                              //if  LookAtTarger is ticked the camera will lock to players location
        }
        else
        {
            transform.eulerAngles = roationLock;               
        }
    }
}
