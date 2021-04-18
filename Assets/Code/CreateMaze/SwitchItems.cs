using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchItems : MonoBehaviour
{
    // Differents items that the user can instantiate and move
    public GameObject[] elts;

    // Allows to know if the current piece is a staircase or not
    private bool isStair = false;
    // Allows to know if the current piece is sludge or not
    private bool isSludge = false;
    // Location of any copies of items
    public GameObject pieces;

    // Prevents the user from placing multiple stairs on the board (protection level = public to switch the value in PlaceItem)
    public bool canPlaceStairD = true;
    public bool canPlaceStairU = true;

    // Create a new instance of the current item and place it at the middle of the grid
    void OnMouseUp()
    {
        // The new piece add to the board
        GameObject newPiece;
        isStair = currentActiveElt(elts).tag == "Start" || currentActiveElt(elts).tag == "End";
        isSludge = currentActiveElt(elts).tag == "Sludge";

        if (isStair)
        {
            if (currentActiveElt(elts) == elts[0] && canPlaceStairD)
            {
                canPlaceStairD = false;

                newPiece = (GameObject)Instantiate(currentActiveElt(elts), Vector2.zero, Quaternion.identity);
                newPiece.transform.parent = pieces.transform;
                newPiece.AddComponent<PlaceItems>();
                PlaceItems myComponent = newPiece.GetComponent<PlaceItems>();
                myComponent.switchItems = GetComponentInParent<SwitchItems>();
                BoxCollider2D myCollider = newPiece.AddComponent<BoxCollider2D>();
                myCollider.isTrigger = true;
            }
            else if (currentActiveElt(elts) == elts[1] && canPlaceStairU)
            {
                canPlaceStairU = false;

                newPiece = (GameObject)Instantiate(currentActiveElt(elts), Vector2.zero, Quaternion.identity);
                newPiece.transform.parent = pieces.transform;
                newPiece.AddComponent<PlaceItems>();
                PlaceItems myComponent = newPiece.GetComponent<PlaceItems>();
                myComponent.switchItems = GetComponentInParent<SwitchItems>();
                BoxCollider2D myCollider = newPiece.AddComponent<BoxCollider2D>();
                myCollider.isTrigger = true;
            }
        }
        else if (!isStair)
        {
            newPiece = (GameObject)Instantiate(currentActiveElt(elts), Vector2.zero, Quaternion.identity);
            newPiece.transform.parent = pieces.transform;
            newPiece.AddComponent<PlaceItems>();
            BoxCollider2D myCollider = newPiece.AddComponent<BoxCollider2D>();

            if (isSludge)
            {
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
            foreach (GameObject elt in elts)
            {
                if (elt.activeInHierarchy == true && i != elts.Length - 1 && elts.Length != 1)
                {
                    elts[i + 1].SetActive(true);
                    elt.SetActive(false);
                    break;
                }
                else if (elt.activeInHierarchy == true && i == elts.Length - 1 && elts.Length != 1)
                {
                    elts[0].SetActive(true);
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
            foreach(GameObject elt in elts)
            {
                if(elt.activeInHierarchy == true)
                {
                    return elt;
                } 
            }
            return null;
        }

}
