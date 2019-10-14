using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
  public void ButtonRestart()
    {
        SceneManager.LoadScene(1);       //when the restart button is selected scene 1 will be loaded
    }

   public void ButtonMenu()
    {
        SceneManager.LoadScene(0);     //when the menu button is selected scene 0 will be loaded
    }

}
