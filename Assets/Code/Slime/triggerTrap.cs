using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTrap : MonoBehaviour
{
    public GameObject defeatWindow;

    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0.0f;
            collision.transform.GetComponent<SlimeMovement>().moveSpeed = 0;
            animator.SetBool("isTrigger", true);
            StartCoroutine(waitAnimation());
            //defeatWindow.SetActive(true);
            //collision.transform.GetComponent<SlimeMovement>().moveSpeed = speed;
        }
    }

    public IEnumerator waitAnimation()
    {
        yield return new WaitForSeconds(2);
        defeatWindow.SetActive(true);
    }

}
