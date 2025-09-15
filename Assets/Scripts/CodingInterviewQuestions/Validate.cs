using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

public class Validate : MonoBehaviour
{
    [SerializeField] List<int> _elemetns;
    [SerializeField] int _matchingElement;

    [Button("MATCHING OUTPUT")]
    public void CheckMatchingAddtion()
    {
        if (_elemetns.Count <= 0)
        {
            return;
        }

        int leftIndex = 0;
        int rightIndex = _elemetns.Count - 1;

        while (leftIndex < rightIndex)
        {
            int totalCount = _elemetns[leftIndex] + _elemetns[rightIndex];
            if (totalCount > _matchingElement)
            {
                rightIndex--;
            }
            else if (totalCount < _matchingElement)
            {
                leftIndex++;
            }
            else
            {
                Debug.Log(_elemetns[leftIndex] + "...." + _elemetns[rightIndex] + "...." + totalCount);
                break;
            }
        }
    }


    [Button("FIND MISSING ELEMENTS IN THE SEQUENCE")]
    public void FindTheMissingElem()
    {
        HashSet<int> found = new HashSet<int>(_elemetns);
        for (int i = 1; i <= _elemetns.Count; i++)
        {
            if (!found.Contains(i))
            {
                Debug.Log($"Missing element in the array was {i}");
                return;
            }
        }
    }
}
