using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class triggerSludge : MonoBehaviour
{
    public float speedDecrease = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SlimeMovement slimeMovement = collision.transform.GetComponent<SlimeMovement>();
            slimeMovement.moveSpeed = slimeMovement.moveSpeed / speedDecrease;
        } else if(collision.transform.CompareTag("AI"))
        {
            AIPath AIMovement = collision.transform.GetComponent<AIPath>();
            AIMovement.maxSpeed = AIMovement.maxSpeed / speedDecrease;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SlimeMovement slimeMovement = collision.transform.GetComponent<SlimeMovement>();
            slimeMovement.moveSpeed = slimeMovement.moveSpeed * speedDecrease;
        } else if(collision.transform.CompareTag("AI"))
        {
            AIPath AIMovement = collision.transform.GetComponent<AIPath>();
            AIMovement.maxSpeed = AIMovement.maxSpeed * speedDecrease;
        }
    }
}
