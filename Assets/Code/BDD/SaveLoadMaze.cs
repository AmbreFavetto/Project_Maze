using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SaveLoadMaze : MonoBehaviour
{
    private readonly string baseURL = "http://127.0.0.1:8080/api/level";
    public IEnumerator save(string levelTitle, string creatorName, string jsonString)
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
            Debug.Log("gg bro");
        }
    }
}
