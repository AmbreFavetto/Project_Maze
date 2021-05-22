using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerifyAndSaveMaze : MonoBehaviour
{
    // To get the instances of the down and up stairs
    public SwitchItems switchItems;

    // To test the maze before save it
    public GameObject slime;
    public GameObject slimeInstance;

    public GameObject startInstance;
    private GameObject endInstance;

    public GameObject btnTest;
    public GameObject btnSave;
    public GameObject btnModify;
    public GameObject btnLoad;

    public SaveLoadMaze saveLoadMaze;

    public GameObject infosWindow;
    public GameObject saveWindow;
    public GameObject errorWindow;
    public GameObject missingInfosWindow;

    public InputField inputNickname;
    public InputField inputInfosMaze;

    private AIPathfinding pathfinding;

    public enum typeOfObject {Angle1 = 1, Angle2 = 2, Angle3 = 3, Angle4 = 4, Line1 = 5, Line2 = 6, Bit1 = 7, Bit2 = 8, Bit3 = 9, Bit4 = 10, Cross = 11, T1 = 12, T2 = 13, T3 = 14, T4 = 15, StartInstance = 16, EndInstance = 17, Sludge = 18, Trap = 19};
    public readonly string[] nameOfObject = { "Angle1", "Angle2", "Angle3", "Angle4", "Line1", "Line2", "Bit1", "Bit2", "Bit3", "Bit4", "Cross", "T1", "T2", "T3", "T4", "StartInstance", "EndInstance", "Sludge", "Trap" };
    public readonly string[] nameOfObstacle = { "Angle1", "Angle2", "Angle3", "Angle4", "Line1", "Line2", "Bit1", "Bit2", "Bit3", "Bit4", "Cross", "T1", "T2", "T3", "T4" };
    
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

            startInstance = GameObject.FindGameObjectWithTag("StartInstance");
            slime.transform.position = startInstance.transform.position;
            slimeInstance = Instantiate(slime);
        }
    }

    public void ShowInfosWindow()
    {
        // To prevent testing or saving if there is not at least one start and one finish
        if (switchItems.canPlaceStairD == false && switchItems.canPlaceStairU == false)
        {
            HideButtons();
            infosWindow.SetActive(true);
        }
    }

    public void SaveMaze()
    {
        pathfinding = new AIPathfinding(18, 11);
        int i = 0;
        string Json = "";

        if (inputNickname.text != "" && inputInfosMaze.text != "")
        {
            infosWindow.SetActive(false);

            startInstance = GameObject.FindGameObjectWithTag("StartInstance");
            endInstance = GameObject.FindGameObjectWithTag("EndInstance");

            foreach (string myObject in nameOfObject) {
                foreach (GameObject newObject in GameObject.FindGameObjectsWithTag(myObject)) {
                    if (newObject.transform.position.x > -10)
                    {
                        i = 0;
                        ItemToSave tmp = new ItemToSave();
                        foreach(string type in nameOfObject) {
                            if(type == myObject)
                            {
                                tmp.type = (typeOfObject)i;
                            }
                            i++;
                        }
                        tmp.pos = newObject.transform.position;                      
                        items.Add(tmp);
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

            List<AIPathNode> path = pathfinding.FindPath((int)startInstance.transform.position.x + 9, 
                                                        (int)startInstance.transform.position.y + 7, 
                                                        (int)endInstance.transform.position.x + 9, 
                                                        (int)endInstance.transform.position.y + 7);

            if (path != null)
            {
                saveWindow.SetActive(true);

                bool debug = true;

                if(debug)
                {
                    for (i = 0; i < path.Count - 1; i++)
                    {
                        Debug.DrawLine(new Vector3(path[i].x - 9, path[i].y - 7), new Vector3(path[i + 1].x - 9, path[i + 1].y - 7), Color.green, 2.5f, false);                   
                    }
                }

                i = 0;
                foreach (ItemToSave item in items)
                {                        
                    if (i == 0)
                    {
                        Json = "[" + JsonUtility.ToJson(item);
                    }
                    else if (i == items.Count - 1)
                    {
                        Json = Json + "," + JsonUtility.ToJson(item) + "]";
                    } else
                    {
                        Json = Json + "," + JsonUtility.ToJson(item);
                    }
                    i++;
                }

                StartCoroutine(saveLoadMaze.Save(inputInfosMaze.text, inputNickname.text, Json));
                items.Clear();
                ShowButtons();

            } else
            {
                errorWindow.SetActive(true);
                ShowButtons();
            }
        } else
        {
            missingInfosWindow.SetActive(true);
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

    private void ShowButtons()
    {
        btnSave.SetActive(true);
        btnTest.SetActive(true);
    }

}
