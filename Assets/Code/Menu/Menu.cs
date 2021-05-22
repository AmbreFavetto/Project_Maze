using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject settingsWindow;


    public void EditMaze()
    {
        SceneManager.LoadScene("MazeEditor");
    }

    public void LaunchMaze()
    {
        SceneManager.LoadScene("MazeTester");
    }

    public void Settings()
    {
        settingsWindow.SetActive(true);
        Time.timeScale = 0.0f;        
    }

    public void CloseSettings()
    {
        settingsWindow.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
