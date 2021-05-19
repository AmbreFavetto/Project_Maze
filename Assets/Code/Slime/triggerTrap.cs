using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTrap : MonoBehaviour
{
    public GameObject defeatWindow;
    // The trap animation
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // To pause the game
            Time.timeScale = 0.0f;
            collision.transform.GetComponent<SlimeMovement>().moveSpeed = 0;
            // To play the animation
            animator.SetBool("isTrigger", true);
            StartCoroutine(waitAnimation());
            defeatWindow.SetActive(true);
        }
    }

    public IEnumerator waitAnimation()
    {
        // TODO : corriger probl�me animation qui se joue apr�s que la fen�tre s'affiche
        yield return new WaitForSeconds(2);
    }

}
