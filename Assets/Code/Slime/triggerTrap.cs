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
        // TODO : corriger problème animation qui se joue après que la fenêtre s'affiche
        yield return new WaitForSeconds(2);
    }

}
