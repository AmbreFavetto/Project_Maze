using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SaveLoadMaze : MonoBehaviour
{
    public GameObject mazeInstance;
    [SerializeField] private Text txtCreator;
    [SerializeField] private Text txtNameMaze;

    private readonly string baseURL = "http://127.0.0.1:8080/api/level";
    private int currentIndex;
    private List<MazeInfos> listMazes;

    public class MazeInfos
    {
        public string id;
        public string mazeName;
        public string url;
    }

  /*  private void Start()
    {
        listMazes = new List<MazeInfos>();
    }*/

    public IEnumerator Save(string levelTitle, string creatorName, string jsonString)
    {
        WWWForm formData = new WWWForm();
        formData.AddField("name", levelTitle);
        formData.AddField("creator", creatorName);
        formData.AddField("maze_data", jsonString);

        UnityWebRequest www = UnityWebRequest.Post(baseURL, formData);
        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        } else
        {
            AddUrlId(levelTitle);
        }
    }

    public IEnumerator Load(string levelTitle) {
        using(UnityWebRequest mazeInfosRequest = UnityWebRequest.Get(GetUrl(levelTitle)))
        {
            string[] mazesInfos;

            yield return mazeInfosRequest.SendWebRequest();
            if (mazeInfosRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(mazeInfosRequest.error);
            }
            else
            {
                string rawInfos = mazeInfosRequest.downloadHandler.text;
                mazesInfos = rawInfos.Split(new string[] { "}," }, StringSplitOptions.None);

                for (int i = 0, counter = 0; i < mazesInfos.Length; i++, counter++)
                {
                    /* Getting the position of the object */
                    float x = getFloat(mazesInfos[i], "x", ":");
                    mazesInfos[i] = mazesInfos[i].Substring(mazesInfos[i].IndexOf(','));
                    float y = getFloat(mazesInfos[i], "y", ":");
                    mazesInfos[i] = mazesInfos[i].Substring(mazesInfos[i].IndexOf(','));
                    float z = 0;

                    i = i + 1;
                    int position = mazesInfos[i].IndexOf(':') + 1;

                    // TODO : creation de l'objet en fonction de son type et de sa position à l'aide d'un switch
                    // switch (mazesInfos[i][position]) {
                    //        case 0 : 
                    //           Instantiate(Angle1, transform.position, Quaternion.identity);
                    //        [...]
                    // }
                }
            }
        }
    }

    private float getFloat(string number, string axis, string endMark)
    {
        number = number.Substring(number.IndexOf(axis) + 3, number.IndexOf(endMark) - 1);
        Debug.Log("float number before convert : " + number);
        float num = float.Parse(number, CultureInfo.InvariantCulture.NumberFormat);
        Debug.Log("float number after convert : " + num);
        return (num);
    }

    public void showMazesToLoad()
    {
        foreach(MazeInfos maze in listMazes)
        {
            GameObject newMazeInstance = Instantiate(mazeInstance);
            //newMazeInstance.transform.GetComponent(txtCreator);

        }
    }

    private void AddUrlId(string levelName)
    {
        StartCoroutine(getLastOccurenceOfId());

        MazeInfos infos = new MazeInfos();
        infos.id = Convert.ToString(currentIndex + 1);
        infos.mazeName = levelName;
        infos.url = baseURL + "/" + Convert.ToString(currentIndex + 1);

        listMazes.Add(infos);
        foreach(MazeInfos maze in listMazes)
        {
            Debug.Log("MAZE : " + maze.id + " " + maze.mazeName + " " + maze.url);
        }
    }

    private IEnumerator getLastOccurenceOfId()
    {

        using(UnityWebRequest mazeInfosRequest = UnityWebRequest.Get(baseURL))
        {
            yield return mazeInfosRequest.SendWebRequest();
            if(mazeInfosRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(mazeInfosRequest.error);
            } else
            {
                string rawInfos = mazeInfosRequest.downloadHandler.text;
                rawInfos = rawInfos.Substring(rawInfos.LastIndexOf("id"));
                Debug.Log("RawInfo : " + rawInfos);
                currentIndex = Convert.ToInt16(rawInfos[4]);
            }
        }
    }

    private string GetUrl(string levelName)
    {
        int i = 0;

        foreach(MazeInfos maze in listMazes)
        {
            if (String.Equals(maze.mazeName, levelName))
            {
                return maze.url;
            }
            i++;
        }
        return ("FAIL");
    }
}
