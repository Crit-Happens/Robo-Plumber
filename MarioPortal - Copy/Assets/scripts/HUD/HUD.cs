using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image healthbar;
    public Text healthText;
    public Text Timer;
    public Sprite[] healthSprites;

    public void Updatehealth(CharacterStats stats)      
    {
        healthText.text = stats.currentHealth + "/" + stats.maxHealth;       //health text is equal to current healt plus the max health
        healthbar.fillAmount = stats.currentHealth / stats.maxHealth;        //the healt bar is equal max health - currenthealth
    }

    public void updateTimer(float time)
    {
        Timer.text = "Timer: " + formatFloatAsTime(time);                    //timer text is = to time
    }

    public string formatFloatAsTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60);                  //this stats the time is = to minutes and seconds
        string timeTag = string.Format("{0:00};{1:00}", minutes, seconds);
        return timeTag;

    }
}
