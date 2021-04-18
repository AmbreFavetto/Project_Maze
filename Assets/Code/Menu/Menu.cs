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
        SceneManager.LoadScene("MazeEditor");
    }

    public void Settings()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsWindow.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
