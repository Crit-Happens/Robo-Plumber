using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Menu : MonoBehaviour
{
   public void ButtonStart()
    {
        SceneManager.LoadScene(1);         //when start button is selected the game goes to scene 1
    }

    public void ButtonCredit()
    {
        SceneManager.LoadScene(2);    //when credit button is selected the game goes to scene 2
    }

    public void ButtonQuit()
    {
        Application.Quit();           //when quit button is selected the application will close
    }
}
