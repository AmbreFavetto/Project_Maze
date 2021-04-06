using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchItems : MonoBehaviour
{
    public GameObject[] elts;
    public GameObject pieces;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseUp()
    {
         GameObject newPiece = (GameObject)Instantiate(isCurrentActiveElt(elts), Vector2.zero, Quaternion.identity);
        newPiece.transform.parent = pieces.transform;
        newPiece.AddComponent<PlaceItems>();
        newPiece.AddComponent<BoxCollider2D>();
    }


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


    GameObject isCurrentActiveElt(GameObject[] elts)
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
