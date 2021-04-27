using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerSludge : MonoBehaviour
{
    public float speedDecrease = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SlimeMovement slimeMovement = collision.transform.GetComponent<SlimeMovement>();
            slimeMovement.moveSpeed = slimeMovement.moveSpeed / speedDecrease;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SlimeMovement slimeMovement = collision.transform.GetComponent<SlimeMovement>();
            slimeMovement.moveSpeed = slimeMovement.moveSpeed * speedDecrease;
        }
    }
}
