using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreButton : MonoBehaviour
{
    public void StartOver()
    {
        SceneManager.LoadScene(0);
        DataManager.IsPlaying = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quiting the game");
    }
}
