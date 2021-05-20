using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EndWindow : MonoBehaviour
{
    // Defeat or victory window
    public GameObject endWindow;
    // To get a reference to startInstance (up stairs) and slimeInstance (player)
    public VerifyAndSaveMaze verifyAndSaveMaze;
    // The trap animation
    public Animator animator;

    private GameObject startInstance;
    private GameObject slimeInstance;

    private void Awake()
    {
        startInstance = verifyAndSaveMaze.startInstance;        
    }

    public void Retry()
    {
        endWindow.SetActive(false);

        // To get the new slime instance
        slimeInstance = verifyAndSaveMaze.slimeInstance;
        slimeInstance.transform.position = startInstance.transform.position;
        slimeInstance.transform.GetComponent<SlimeMovement>().moveSpeed = 205;
    }
}
