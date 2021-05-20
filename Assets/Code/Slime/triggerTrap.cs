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
            collision.transform.GetComponent<SlimeMovement>().moveSpeed = 0;
            // To play the animation
            animator.SetTrigger("activeTrap");
            StartCoroutine(waitAnimation());
        }
    }

    public IEnumerator waitAnimation()
    {
        // TODO : corriger probl�me animation qui se joue apr�s que la fen�tre s'affiche
        yield return new WaitForSeconds(1f);
        defeatWindow.SetActive(true);
    }

}
