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
        // TODO : corriger problème animation qui se joue après que la fenêtre s'affiche
        yield return new WaitForSeconds(1f);
        defeatWindow.SetActive(true);
    }

}
