using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Linq;

public class ValidateSysmbols : MonoBehaviour
{
    [SerializeField] List<string> _listOfSymbols;
    [SerializeField] List<string> _openBrackes;
    [SerializeField] List<string> _closedBrackes;
    [SerializeField] List<string> _temp;

    [Button("VALIDATE")]
    public void CheckForValidate()
    {
        _temp = new List<string>(_listOfSymbols);
        Stack<string> stack = new Stack<string>();

        for (int curIndex = 0; curIndex < _temp.Count; curIndex++)
        {
            string currentSymbol = _temp[curIndex];

            if (_openBrackes.Contains(currentSymbol))
            {
                // Push the open bracket onto the stack
                stack.Push(currentSymbol);
            }
            else if (_closedBrackes.Contains(currentSymbol))
            {
                int closedIndex = _closedBrackes.IndexOf(currentSymbol);

                // Check if the stack has a matching open bracket
                if (stack.Count > 0 && _openBrackes.IndexOf(stack.Peek()) == closedIndex)
                {
                    stack.Pop(); // Remove the matching open bracket
                }
                else
                {
                    Debug.Log($"Unmatched closing bracket: {currentSymbol}");
                    return;
                }
            }
            else
            {
                Debug.Log($"Unmatched closing bracket: {currentSymbol}");
                return;
            }
        }

        // If the stack is empty, the brackets are valid
        if (stack.Count == 0)
        {
            Debug.Log("Brackets are valid!");
        }
        else
        {
            Debug.Log($"Unmatched open brackets remain: {string.Join(", ", stack)}");
        }
    }
}