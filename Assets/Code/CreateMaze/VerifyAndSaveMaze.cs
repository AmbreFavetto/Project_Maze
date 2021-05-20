using System;
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

    public SaveLoadMaze saveLoadMaze;

    private AIPathfinding pathfinding;

    public enum typeOfObject {Angle1, Angle2, Angle3, Angle4, Line1, Line2, Bit1, Bit2, Bit3, Bit4, Cross, T1, T2, T3, T4, Start, End, Sludge, Trap};
    public string[] nameOfObject = { "Angle1", "Angle2", "Angle3", "Angle4", "Line1", "Line2", "Bit1", "Bit2", "Bit3", "Bit4", "Cross", "T1", "T2", "T3", "T4", "Start", "End", "Sludge", "Trap" };
    public string[] nameOfObstacle = { "Angle1", "Angle2", "Angle3", "Angle4", "Line1", "Line2", "Bit1", "Bit2", "Bit3", "Bit4", "Cross", "T1", "T2", "T3", "T4" };
    
    [Serializable]
    public class ItemToSave {
        public typeOfObject type;
        public Vector3 pos;
    }

    private List<ItemToSave> items;

    private void Start()
    {
        items = new List<ItemToSave>();
    }

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
        int i = 0;
        // To prevent testing or saving if there is not at least one start and one finish
        if (switchItems.canPlaceStairD == false && switchItems.canPlaceStairU == false)
        {
            HideButtons();

            startInstance = GameObject.FindGameObjectWithTag("StartInstance");
            endInstance = GameObject.FindGameObjectWithTag("EndInstance");          

            foreach (string myObject in nameOfObject) {
                foreach (GameObject newObject in GameObject.FindGameObjectsWithTag(myObject)) {
                    if (newObject.transform.position.x > -10)
                    {
                        i = 0;
                        ItemToSave shrek = new ItemToSave();
                        foreach(string type in nameOfObject) {
                            if(type == myObject)
                            {
                                shrek.type = GetType(i);
                            }
                            i++;
                        }
                        shrek.pos = newObject.transform.position;                      
                        items.Add(shrek);
                    }
                }
            }

            List<GameObject> obstacles = new List<GameObject>();
            foreach (string myObject in nameOfObstacle)
            {
                foreach (GameObject newObject in GameObject.FindGameObjectsWithTag(myObject))
                {
                    if(newObject.transform.position.x > -10)
                    {
                        obstacles.Add(newObject);
                    }
                    
                }
            }

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
                for (i = 0; i < path.Count - 1; i++)
                {
                    Debug.Log(path[i].x + " " + path[i].y);
                    Debug.DrawLine(new Vector3(path[i].x - 9, path[i].y - 7), new Vector3(path[i + 1].x - 9, path[i + 1].y - 7), Color.green, 2.5f, false);
                    
                }
                foreach(ItemToSave item in items)
                {
                    Debug.Log(item.type + " " + item.pos);
                }
                string Json = JsonUtility.ToJson(items, true);

                Debug.Log(Json);
                StartCoroutine(saveLoadMaze.save("coucou", "la mif", Json));
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

    private typeOfObject GetType(int i)
    {
        Debug.Log("LA " +i);
        switch(i)
        {
            case 0:
                return typeOfObject.Angle1;
            case 1:
                return typeOfObject.Angle2;
            case 2:
                return typeOfObject.Angle3;
            case 3:
                return typeOfObject.Angle4;
            case 4:
                return typeOfObject.Line1;
            case 5:
                return typeOfObject.Line2;
            case 6:
                return typeOfObject.Bit1;
            case 7:
                return typeOfObject.Bit2;
            case 8:
                return typeOfObject.Bit3;
            case 9:
                return typeOfObject.Bit4;
            case 10:
                return typeOfObject.Cross;
            case 11:
                return typeOfObject.T1;
            case 12:
                return typeOfObject.T2;
            case 13:
                return typeOfObject.T3;
            case 14:
                return typeOfObject.T4;
            case 15:
                return typeOfObject.Start;
            case 16:
                return typeOfObject.End;
            case 17:
                return typeOfObject.Sludge;
            case 18:
                return typeOfObject.Trap;
            default:
                return typeOfObject.Angle1;
        }
    }
}
