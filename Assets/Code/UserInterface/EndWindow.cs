using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWindow : MonoBehaviour
{
    public GameObject endWindow;
    public VerifyAndSaveMaze verifyAndSaveMaze;
    public Animator animator;

    private GameObject spawnPoint;
    private GameObject slime;

    private void Awake()
    {
        spawnPoint = verifyAndSaveMaze.spawnPoint;
        slime = verifyAndSaveMaze.slime;
        
    }

    public void Retry()
    {
        Time.timeScale = 1.0f;
        animator.SetBool("isTrigger", false);
        endWindow.SetActive(false);
        slime.transform.position = spawnPoint.transform.position;
        slime.transform.GetComponent<SlimeMovement>().moveSpeed = 205;
    }
}
