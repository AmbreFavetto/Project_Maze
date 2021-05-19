using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    // table of all available resolutions with user screen
    Resolution[] resolutions;

    public void Start()
    {
        // recovery of all available resolutions with the user's screen
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        // empty the list of displayed resolutions before filling it
        resolutionDropdown.ClearOptions();
        // list to retrieve the resolutions to be assigned to the drop-down menu
        List<string> options = new List<string>();
        // index used to initialize our default resolution
        int currentResolutionIndex = 0;

        // Adding the different resolutions to the list
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            // Find the user's default resolution
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        // Assign the retrieved resolutions to the drop-down menu
        resolutionDropdown.AddOptions(options);
        // Initialize the user's default resolution
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Changes the resolution according to the item selected by the user
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Change the volume with a slidebar
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    // Put the game in full screen
    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void returnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        // Remove the pause from the game
        Time.timeScale = 1.0f;
    }

}
