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

    // TODO : enlever canPlaceSlime et juste empêcher le clic sur le bouton
    private bool canPlaceSlime = true;

    public void TestMaze()
    {
        if (switchItems.canPlaceStairD == false && switchItems.canPlaceStairU == false && canPlaceSlime)
        {
            startInstance = GameObject.FindGameObjectWithTag("StartInstance");
            slime.transform.position = startInstance.transform.position;
            slime = Instantiate(slime);       
            
            canPlaceSlime = false; // TODO CHANGER
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

            canPlaceSlime = false; // TODO CHANGER
        }
    }
}
