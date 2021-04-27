using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpWindow : MonoBehaviour
{
    public GameObject helpWindow;
    public GameObject[] panels;

    public void ShowHelpWindow()
    {
        helpWindow.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void CloseHelpWindow()
    {
        helpWindow.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void SwitchHelpWindowRight()
    {
        int i = 0;
        foreach (GameObject panel in panels)
        {
            if (panel.activeInHierarchy == true && i != panels.Length - 1 && panels.Length != 1)
            {
                panels[i + 1].SetActive(true);
                panel.SetActive(false);
                break;
            }
            // loop on the first panel
            else if (panel.activeInHierarchy == true && i == panels.Length - 1 && panels.Length != 1)
            {
                panels[0].SetActive(true);
                panel.SetActive(false);
                break;
            }
            i++;
        }
    }

    public void SwitchHelpWindowLeft()
    {
        int i = 0;
        foreach (GameObject panel in panels)
        {
            if (panel.activeInHierarchy == true && i != 0 && panels.Length != 1)
            {
                panels[i - 1].SetActive(true);
                panel.SetActive(false);
                break;
            }
            // loop on the first panel
            else if (panel.activeInHierarchy == true && i == 0 && panels.Length != 1)
            {
                panels[panels.Length - 1].SetActive(true);
                panel.SetActive(false);
                break;
            }
            i++;
        }
    }
}
