using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GetData : MonoBehaviour
{
    [SerializeField] string _baseUrl;
    [SerializeField] List<Todo> _listOfData;

    private void Start()
    {
        _baseUrl = "https://dummyjson.com/todos?limit=20";
        StartCoroutine(GetDetails());
    }
    IEnumerator GetDetails()
    {
        using UnityWebRequest request = UnityWebRequest.Get(_baseUrl);
        request.SetRequestHeader("Accept", "application/json");
        // Send the request
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string jsonResponse = request.downloadHandler.text;
            TodoDatas responseData = JsonUtility.FromJson<TodoDatas>(jsonResponse);
            _listOfData = responseData.todos;
            for (int i = 0; i < responseData.todos.Count; i++)
            {
                GameEvents.SPAWN_TODO?.Invoke(responseData.todos[i]);
            }
        }
        else
        {
            Debug.LogError($"Error: {request.error}");
        }
    }

}

[System.Serializable]
public class TodoDatas
{
    public List<Todo> todos;
    public int total;
    public int skip;
    public int limit;
}

[System.Serializable]
public struct Todo
{
    public int id;
    public string todo;
    public bool completed;
    public int userId;
}
/*{ "id":1,"todo":"Do something nice for someone you care about","completed":false,"userId":152}*/