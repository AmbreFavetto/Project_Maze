using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceItems : MonoBehaviour
{

    public SwitchItems switchItems;

    // positions after which the user can't put an item
    private float minPosX = -10;
    private float maxPosX = 10;
    private float minPosY = -8;
    private float maxPosY = 5;

    private void OnMouseDrag()
    {
        // Deplace items on grid
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // convert movement into int to have deplacements on a sort of grid
        Vector2 roundPoint = new Vector2((int)point.x + 0.5f, (int)point.y + 0.5f);
        transform.position = roundPoint;

        // TODO : To change method to prevent the player to quit the board with an item (?)
        // Method to prevent the player to quit the board with an item
        if (transform.position.x > maxPosX)
        {
            transform.position = Vector2.right * (maxPosX - 1);
        } else if(transform.position.x < minPosX)
        {
            transform.position = Vector2.right * (minPosX+1);
        } else if(transform.position.y > maxPosY)
        {
            transform.position = Vector2.up * (maxPosY-1);
        } else if (transform.position.y < minPosY)
        {
            transform.position = Vector2.up * (minPosY + 1);
        }


    }

    // Destroy selected item on right click
    private void OnMouseOver()
    {
        // Detect right click
        if (Input.GetMouseButtonUp(1))
        {
            if(gameObject.tag == "start")
            {
                // Give the possibility to replace a start item
                switchItems.canPlaceStairD = true;
            } else if (gameObject.tag == "end")
            {
                // Give the possibility to replace an end item
                switchItems.canPlaceStairU = true;
            }
            // destroy the selected item
            Destroy(gameObject);
            
        }
    }
}
