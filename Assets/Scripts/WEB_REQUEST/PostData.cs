using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

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
}