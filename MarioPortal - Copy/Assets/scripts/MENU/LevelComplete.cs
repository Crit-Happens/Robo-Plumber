using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
  public void FinishMenu()
    {
        SceneManager.LoadScene(4);   //when the level finishes the game will load scene 4
    }
}
