using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class MaxChankToSorted : MonoBehaviour
{
    [SerializeField] List<int> _listOfNumbers;

    [Button("MaxChankToSorted")]
    public void SortMaxChank()
    {
        int totalMaxChankCount = 0;
        int curMaxChank = _listOfNumbers[0];
        for (int curIndex = 0; curIndex < _listOfNumbers.Count; curIndex++)
        {
            curMaxChank = Mathf.Max(curMaxChank, _listOfNumbers[curIndex]);
            Debug.Log(curMaxChank+"...."+ curIndex+".."+ _listOfNumbers[curIndex]);
            if (curMaxChank == curIndex)
            {
                totalMaxChankCount++;
            }
            Debug.Log(totalMaxChankCount);
        }
    }

}
