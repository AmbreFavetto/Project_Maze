using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyAndSaveMaze : MonoBehaviour
{
    public SwitchItems switchItems;
    public GameObject slime;
    public GameObject AISlime;

    public GameObject startInstance;
    private GameObject endInstance;

    // TODO : enlever canPlaceSlime et juste emp�cher le clic sur le bouton
    private bool canPlaceSlime = true;

    public void TestMaze()
    {
        if (switchItems.canPlaceStairD == false && switchItems.canPlaceStairU == false && canPlaceSlime)
        {
            startInstance = GameObject.FindGameObjectWithTag("StartInstance");
            slime.transform.position = startInstance.transform.position;
            slime = Instantiate(slime);

            //TODO faire disparaitre les boutons SAVE et TEST
            //     faire apparaitre un bouton MODIFIER
            canPlaceSlime = false; // TODO Supprimer
        }
    }

    public void SaveMaze()
    {        

        if (switchItems.canPlaceStairD == false && switchItems.canPlaceStairU == false && canPlaceSlime)
        {
            AstarPath.active.Scan();

            startInstance = GameObject.FindGameObjectWithTag("StartInstance");
            endInstance = GameObject.FindGameObjectWithTag("EndInstance");

            AISlime.transform.position = startInstance.transform.position;
            AISlime = Instantiate(AISlime);
            AISlime.transform.GetComponent<Pathfinding.AIDestinationSetter>().target = endInstance.transform;

            //TODO faire disparaitre les boutons SAVE et TEST
            canPlaceSlime = false; // TODO Supprimer

            // TODO si IA arrive 
            //              Faire apparaitre une fenetre "sauvegarde effectu�e"
            //      sinon 
            //              Faire apparaitre une fenetre "error"


        }
    }
}
