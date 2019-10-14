using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage: MonoBehaviour
{

    public enum DamageType
    {
        Instant                           //Damage is instant
    }

    public DamageType hazardType;
    public float damage;
    public float coolDown;
    public bool respawn;
    public bool triggered = false;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if(triggered == false)
        {
            if(other.tag == "Player")                 //the player can trigger the TriggerHazard (which will be a game object)
            {
                TriggerHazard(other.gameObject);
            }
        }
    }
   
   
    public void TriggerHazard(GameObject go)
    {
        if(hazardType == DamageType.Instant)
        {
            go.GetComponent<CharacterStats>().TakeDamage(damage);            //the HazardType is equal to the damage type and when the player triggers the triggerHazard the TakeDamage function will be called then the triggerHazard will go on cooldown
        }
        StartCoroutine(Cooldown());
    }
   
  
    IEnumerator Cooldown()
    {
        triggered = true;
        GetComponent<MeshRenderer>().enabled = false;                        //When the player triggers the gameobject then mesh renderer will be disbaled for a set amount of seconds and if the respawn box is ticked the mesh renderer will be active after the set amount of
        yield return new WaitForSeconds(coolDown);                           //seconds if unticked the gameObjects wont be active
        if(respawn == true)
        {
            GetComponent<MeshRenderer>().enabled = true;
            triggered = false;
        }
        else
        {
            gameObject.SetActive(false);
        }
            
    }

}    