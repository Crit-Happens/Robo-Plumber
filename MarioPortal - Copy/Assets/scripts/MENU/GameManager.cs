using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1f;               //open variable that delays the restart of the game
    public GameObject completeLevelUI;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);         //A Image will appear stating that you completed the level
    }
   
    public void GameOver()
    {
        Debug.Log("GAME OVER");
        Restart();                                //when player dies or fails a log will appear in the console saying GAME OVER and the game will restart
        Invoke("Restart", restartDelay);
    }

    void Restart()
    {
        SceneManager.LoadScene(3);             //when the game restarts it will load scene 3
    }
}
