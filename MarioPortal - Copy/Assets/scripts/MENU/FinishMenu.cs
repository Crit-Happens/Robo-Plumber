using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishMenu : MonoBehaviour
{
  public void ButtonNextLevel()
    {
        SceneManager.LoadScene(5);    //when the next level button is selected scene 5 will be loaded
    }

    public void ButtonRestart()
    {
        SceneManager.LoadScene(1);      //when the restart button is selected the current scene will be loaded
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene(0);      //when the main menu button is selected scene 0 will be loaded
    }

}
