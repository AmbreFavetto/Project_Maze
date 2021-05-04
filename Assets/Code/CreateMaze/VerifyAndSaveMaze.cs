using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyAndSaveMaze : MonoBehaviour
{
    public SwitchItems switchItems;
    public GameObject slime;
    public GameObject spawnPoint;

    private GameObject startInstance;
    // TODO : enlever canPlaceSlime et juste empêcher le clic sur le bouton
    private bool canPlaceSlime = true;

    public void TestMaze()
    {
        if (switchItems.canPlaceStairD == false && switchItems.canPlaceStairU == false && canPlaceSlime)
        {
            startInstance = GameObject.FindGameObjectWithTag("StartInstance");
            spawnPoint.transform.position = startInstance.transform.position;
            slime.transform.position = spawnPoint.transform.position;
            slime = Instantiate(slime);          
            canPlaceSlime = false;
        }
    }

    public void SaveMaze()
    {
        AstarPath.active.Scan();
    }
}
