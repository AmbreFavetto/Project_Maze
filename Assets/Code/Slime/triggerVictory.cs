using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerVictory : MonoBehaviour
{
    public GameObject victoryWindow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Time.timeScale = 0.0f;
            victoryWindow.SetActive(true);
        } 
    }
}
