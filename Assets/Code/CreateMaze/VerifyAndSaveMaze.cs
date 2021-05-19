using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyAndSaveMaze : MonoBehaviour
{
    // To get the instances of the down and up stairs
    public SwitchItems switchItems;

    public GameObject slime;
    public GameObject slimeInstance;

    public GameObject startInstance;
    private GameObject endInstance;

    public GameObject btnTest;
    public GameObject btnSave;
    public GameObject btnModify;

    private AIPathfinding pathfinding;

    public void TestMaze()
    {
        // To prevent testing or saving if there is not at least one start and one finish
        if (switchItems.canPlaceStairD == false && switchItems.canPlaceStairU == false)
        {
            HideButtons();
            btnModify.SetActive(true);

            //switchItems.enabled = false;
            //placeItems.enabled = false;
            
            startInstance = GameObject.FindGameObjectWithTag("StartInstance");
            slime.transform.position = startInstance.transform.position;
            slimeInstance = Instantiate(slime);
        }
    }

    public void SaveMaze()
    {
        pathfinding = new AIPathfinding(18, 11);

        // To prevent testing or saving if there is not at least one start and one finish
        if (switchItems.canPlaceStairD == false && switchItems.canPlaceStairU == false)
        {
            HideButtons();

            startInstance = GameObject.FindGameObjectWithTag("StartInstance");
            endInstance = GameObject.FindGameObjectWithTag("EndInstance");

            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

            foreach (GameObject obstacle in obstacles)
            {
                MazeGrid<AIPathNode> grid = pathfinding.GetGrid();
                grid.GetGridObject((int)(obstacle.transform.position.x + 9), (int)(obstacle.transform.position.y + 7)).SetIsWalkable(false);
            }

            List<AIPathNode> path = pathfinding.FindPath((int)startInstance.transform.position.x + 9, (int)startInstance.transform.position.y + 7, (int)endInstance.transform.position.x + 9, (int)endInstance.transform.position.y + 7);

            if (path != null)
            {
                // TODO : Chargement en BD
                Debug.Log("OK!");
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.Log(path[i].x + " " + path[i].y);
                    Debug.DrawLine(new Vector3(path[i].x - 9, path[i].y - 7), new Vector3(path[i + 1].x - 9, path[i + 1].y - 7), Color.green, 2.5f, false);
                }
            } else
            {
                // TODO : Affichage de la fenêtre indiquant qu'il y a une erreur
                Debug.Log("NULL!");
            }

            /*AISlime.transform.position = startInstance.transform.position;

            
            AISlime = Instantiate(AISlime);
            AISlime.GetComponent<AIController>().SetTargetPosition(endInstance.transform.position);
            */

            

        }
    }

    public void ModifyMaze()
    {
        btnSave.SetActive(true);
        btnTest.SetActive(true);
        btnModify.SetActive(false);

        Destroy(slimeInstance);
    }

    private void HideButtons()
    {
        btnSave.SetActive(false);
        btnTest.SetActive(false);
    }
}
