using UnityEngine;
using TMPro;

public class TodoTaskMsg : MonoBehaviour
{
    [SerializeField] Todo _todo;
    [SerializeField] TMP_Text _message;
    [SerializeField] TMP_Text _todoId;
    [SerializeField] TMP_Text _todoStatus;
    [SerializeField] TMP_Text _userId;
    [SerializeField] public int id = 0;
    public void ShowMessage(Todo todoData)
    {
        _todo = todoData;
        id = _todo.id;
        _message.SetText(_todo.todo);
        _todoId.SetText(_todo.id.ToString());
        _todoStatus.SetText(_todo.completed.ToString());
        _userId.SetText(_todo.userId.ToString());
    }
}
