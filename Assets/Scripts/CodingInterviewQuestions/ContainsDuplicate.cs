using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System;

public class ContainsDuplicate : MonoBehaviour
{
    [SerializeField] List<int> _listOfNumbers;
/*NOT WORKING SOLUTION
    [Button("DUPLICATES SOLUTION 1")]
    public void FindDuplicatesInTheArray()
    {
        try
        {
            if (_listOfNumbers == null || _listOfNumbers.Count == 0)
            {
                Debug.Log("The array is empty or null.");
                return;
            }

            List<int> _copyArr = _listOfNumbers;
            _copyArr.Sort();

            int leftIndex = 0;
            int rightIndex = _listOfNumbers.Count - 1;

            while (leftIndex < rightIndex)
            {
                if (_copyArr[leftIndex] == _copyArr[rightIndex])
                {
                    Debug.Log(_copyArr[leftIndex] + "...EQUAL...");
                    break;
                }
                else if (_copyArr[leftIndex] < _copyArr[rightIndex])
                {
                    Debug.Log(_copyArr[leftIndex] + "...LESS THAN..." + _copyArr[rightIndex]);
                    leftIndex++;
                }
                else
                {
                    Debug.Log(_copyArr[leftIndex] + "...GRATER THAN..." + _copyArr[rightIndex]);
                    rightIndex--;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }*/

    [Button("DUPLICATES SOLUTION 2")]
    public void FindDuplicatesInTheArraysSolution2()
    {
        try
        {
            if (_listOfNumbers == null || _listOfNumbers.Count == 0)
            {
                Debug.Log("The array is empty or null.");
                return;
            }

            HashSet<int> seen = new HashSet<int>();

            foreach (int num in _listOfNumbers)
            {
                if (seen.Contains(num))
                {
                    // return true;
                    Debug.Log("ARRAY CONTAINS DUPLICATES..." + num);
                    break;
                }
                seen.Add(num);
            }

            //return false;
        }
        catch (Exception ex)
        {
            Debug.LogError("An error occurred: " + ex.Message);
        }
    }
}
