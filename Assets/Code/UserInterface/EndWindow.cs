using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EndWindow : MonoBehaviour
{
    public GameObject endWindow;
    public VerifyAndSaveMaze verifyAndSaveMaze;
    public Animator animator;

    private GameObject startInstance;
    private GameObject slimeInstance;
    private GameObject AISlimeInstance;

    private void Awake()
    {
        startInstance = verifyAndSaveMaze.startInstance;
        slimeInstance = verifyAndSaveMaze.slime;
        AISlimeInstance = verifyAndSaveMaze.AISlime;
        
    }

    public void Retry()
    {
        Time.timeScale = 1.0f;
        animator.SetBool("isTrigger", false);
        endWindow.SetActive(false);  

        /*slimeInstance.transform.position = startInstance.transform.position;
        slimeInstance.transform.GetComponent<SlimeMovement>().moveSpeed = 205;*/

        AISlimeInstance.transform.position = startInstance.transform.position;
        AISlimeInstance.transform.GetComponent<AIPath>().maxSpeed = 2;
    }
}
