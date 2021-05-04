using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchItems : MonoBehaviour
{
    // Differents items that the user can instantiate and move
    public GameObject[] elts;

    // Lets you know what type of piece the current piece is
    private bool isStair = false;
    private bool isSludge = false;
    private bool isTrap = false;

    // Location of any copies of items
    public GameObject pieces;

    // To spawn the slime on the start stair
    public GameObject SpawnPoint;

    // Prevents the user from placing multiple stairs on the board (protection level = public to switch the value in PlaceItem)
    public bool canPlaceStairD = true;
    public bool canPlaceStairU = true;

    // Create a new instance of the current item and place it at the middle of the grid
    void OnMouseUp()
    {
        GameObject newPiece;
        // To find out if the piece the user wants to add is a stair, sludge or trap
        isStair = currentActiveElt(elts).tag == "Start" || currentActiveElt(elts).tag == "End";
        isSludge = currentActiveElt(elts).tag == "Sludge";
        isTrap = currentActiveElt(elts).tag == "Trap";

        if (isStair)
        {
            // To find out if the piece the user wants to add is a starting staircase
            if (currentActiveElt(elts) == elts[0] && canPlaceStairD)
            {
                canPlaceStairD = false;

                // creates an instance of the piece on which the user has clicked and places this new piece in the center of the board
                newPiece = (GameObject)Instantiate(currentActiveElt(elts), Vector2.zero, Quaternion.identity);
                newPiece.transform.parent = pieces.transform;
                // Add the script PlaceItems to the new piece to move and delete it
                newPiece.AddComponent<PlaceItems>();
                // The tag StartInstance is useful for the appearance of the slime in the right place (on the starting stairs)
                newPiece.tag = "StartInstance";
                // Add a reference to SwitchItems to set canPlaceStairD to true on the delete of the piece
                PlaceItems myComponent = newPiece.GetComponent<PlaceItems>();
                myComponent.switchItems = GetComponentInParent<SwitchItems>();
                // Add a boxCollider2D on the newPiece to move it
                BoxCollider2D myCollider = newPiece.AddComponent<BoxCollider2D>();
                myCollider.isTrigger = true;
            }
            //To know if the piece the user wants to add is an arrival staircase
            else if (currentActiveElt(elts) == elts[1] && canPlaceStairU)
            {
                canPlaceStairU = false;

                // creates an instance of the piece on which the user has clicked and places this new piece in the center of the board
                newPiece = (GameObject)Instantiate(currentActiveElt(elts), Vector2.zero, Quaternion.identity);
                newPiece.transform.parent = pieces.transform;
                // Add the script PlaceItems to the new piece to move and delete it
                newPiece.AddComponent<PlaceItems>();
                // The tag EndInstance is useful for the AISlime
                newPiece.tag = "EndInstance";
                // Add a reference to SwitchItems to set canPlaceStairU to true on the delete of the piece
                PlaceItems myComponent = newPiece.GetComponent<PlaceItems>();
                myComponent.switchItems = GetComponentInParent<SwitchItems>();
                // Add a boxCollider2D on the newPiece to move it
                BoxCollider2D myCollider = newPiece.AddComponent<BoxCollider2D>();
                myCollider.isTrigger = true;
            }
        }
        else if (!isStair)
        {
            // creates an instance of the piece on which the user has clicked and places this new piece in the center of the board
            newPiece = (GameObject)Instantiate(currentActiveElt(elts), Vector2.zero, Quaternion.identity);
            newPiece.transform.parent = pieces.transform;
            // Add the script PlaceItems to the new piece to move and delete it
            newPiece.AddComponent<PlaceItems>();
            // Add a boxCollider2D on the newPiece to move it
            BoxCollider2D myCollider = newPiece.AddComponent<BoxCollider2D>();
            if (isSludge || isTrap)
            {
                // set the trigger to true to be able to interact with the sludge (slow down the slime when it passes over)
                myCollider = newPiece.GetComponent<BoxCollider2D>();
                myCollider.isTrigger = true;
            }
        }
   
    }

    // Switch the visible item on right click
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1))
        {
            int i = 0;
            // We go through the different elements of the list to find the one that is activated
            foreach (GameObject elt in elts)
            {
                if (elt.activeInHierarchy == true && i != elts.Length - 1 && elts.Length != 1)
                {
                    // activates the next element
                    elts[i + 1].SetActive(true);
                    // disables the current element
                    elt.SetActive(false);
                    break;
                }
                // If we reach the last element of the list
                else if (elt.activeInHierarchy == true && i == elts.Length - 1 && elts.Length != 1)
                {
                    // activates the first element
                    elts[0].SetActive(true);
                    // disables the current element
                    elt.SetActive(false);
                    break;
                }
                i++;
            }
        }
    }

    // Give the current item to duplicate him on the grid
    GameObject currentActiveElt(GameObject[] elts)
    {
        // We go through the different elements of the list to find the one that is activated
        foreach (GameObject elt in elts)
        {
            if(elt.activeInHierarchy == true)
            {
                return elt;
            } 
        }
        // event that is never supposed to happen
        return null;
    }

}
