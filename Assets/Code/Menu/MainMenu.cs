using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsWindow;

    public void EditWaze()
    {
        SceneManager.LoadScene("MazeEditor");
    }

    public void LaunchWaze()
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
