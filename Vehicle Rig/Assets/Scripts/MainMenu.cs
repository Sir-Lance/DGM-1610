using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        Screen.lockCursor = false;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("QUITTING GAME");
        Application.Quit();
    }
}
