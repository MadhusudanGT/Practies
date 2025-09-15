using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SocialPlatforms.Impl;

public class PostData : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SendPostRequest("https://httpbin.org/post"));
    }

    IEnumerator SendPostRequest(string url)
    {
        WWWForm form = new();
        form.AddField("username", "Player123");
        form.AddField("score", 100);


        // Send the POST request
        UnityWebRequest request = UnityWebRequest.Post(url, form);

        /* UserData userData = new()
         {
             username = "Player123",
             score = "100"
         };
         byte[] data = Encoding.UTF8.GetBytes(userData.ToString());

         using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
         {
             request.uploadHandler = new UploadHandlerRaw(data);
             request.downloadHandler = new DownloadHandlerBuffer();
             request.SetRequestHeader("Content-Type", "application/json");
             request.SetRequestHeader("Authorization", "Bearer " + authToken);

             yield return request.SendWebRequest();

             if (request.result == UnityWebRequest.Result.Success)
             {
                 Debug.LogError("Error: " + request.downloadHandler.text);
             }
             else
             {
                 Debug.LogError("Error: " + request.error);
             }
         }*/

        yield return request.SendWebRequest();

        // Handle the response
        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Response: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }

    /*    void Start()
        {
            StartCoroutine(PostRequest(apiUrl, "{ \"title\": \"Test\", \"body\": \"Hello World\", \"userId\": 1 }"));
        }*/

    IEnumerator PostRequest(string url, string jsonData)
    {
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Response: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error: " + request.error);
            }
        }
    }
}

[System.Serializable]
public struct UserData
{
    public string username;
    public string score;
}