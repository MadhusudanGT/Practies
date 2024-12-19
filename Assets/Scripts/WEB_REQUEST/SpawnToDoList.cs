using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class SpawnToDoList : MonoBehaviour
{
    [SerializeField] List<TodoTaskMsg> _listOfPanels;
    [SerializeField] TodoTaskMsg _prefab;
    [SerializeField] Transform parent;
    [SerializeField] List<Todo> _todoData;
    [SerializeField] TMP_InputField _filter;

    private void OnEnable()
    {
        _filter.onValueChanged?.AddListener(ApplyFilter);
        GameEvents.SPAWN_TODO += SpawnToDo;
    }

    private void OnDisable()
    {
        _filter.onValueChanged?.RemoveListener(ApplyFilter);
        GameEvents.SPAWN_TODO -= SpawnToDo;
    }

    public void SpawnToDo(Todo todoData)
    {
        bool id = _todoData.Exists(item => item.userId == todoData.userId);
        TodoTaskMsg todo = Instantiate(_prefab);
        _listOfPanels.Add(todo);
        todo.ShowMessage(todoData);
        todo.transform.SetParent(parent);
        todo.transform.position = Vector3.zero;
        todo.transform.localScale = Vector3.one;
    }

    void ApplyFilter(string filterText)
    {
        if (int.TryParse(filterText, out int filterId))
        {
            List<TodoTaskMsg> filteredData1 = _listOfPanels
                   .Where(d => d.id > filterId)
                   .ToList();
            ToggleData(filteredData1, false);
            List<TodoTaskMsg> filteredData = _listOfPanels
                    .Where(d => d.id <= filterId)
                    .ToList();
            ToggleData(filteredData, true);
        }
    }

    void ToggleData(List<TodoTaskMsg> data,bool status)
    {
        foreach (TodoTaskMsg item in data)
        {
            item.transform.gameObject.SetActive(status);
        }
    }
}
