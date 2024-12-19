using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

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
        int rightIndex = _elemetns.Count -1;

        while (leftIndex < rightIndex)
        {
            int totalCount = _elemetns[leftIndex] + _elemetns[rightIndex];
            if (totalCount > _matchingElement)
            {
                rightIndex--;
            }else if (totalCount < _matchingElement)
            {
                leftIndex++;
            }
            else
            {
                Debug.Log(_elemetns[leftIndex]+"...."+ _elemetns[rightIndex]+"...."+ totalCount);
                break;
            }
        }
    }
}
