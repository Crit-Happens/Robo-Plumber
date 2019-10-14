using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth; //<--- Read Only

    private PlayerControl pControl;
    private CharacterController charController;
    private HUD hud;

    // Start is called before the first frame update
    void Start()
    {
        pControl = GetComponent<PlayerControl>(); //grabs the playercontrol 
        charController = GetComponent<CharacterController>(); //grabs the characterController
        hud = GetComponent<HUD>(); //grabs the HUD class
        currentHealth = maxHealth; //current health is equal max health 
        hud.Updatehealth(this);
    }

    public void GainHealth(float Heal)
    { 

        if (currentHealth < maxHealth)
            currentHealth += Heal;                    //GainHealth heals the player and shows it in the HUD
            hud.Updatehealth(this);
        
    }

    public void TakeDamage(float damage) 
    {
        currentHealth -= damage;
        hud.Updatehealth(this);                  //TakeDamage deals damage to the player and shows it on the HUD and if Health is equal to or less then 0 then the player dies
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        //GetComponent<MeshRenderer>().enabled = false;
        pControl.enabled = false;
        charController.enabled = false;                          //when the player dies their player controller stops working character controller stops working and  the GameOver function is called from the GameManager script
        FindObjectOfType<GameManager>().GameOver();
    }
}