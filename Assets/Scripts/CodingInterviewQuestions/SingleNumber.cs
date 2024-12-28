using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

public class SingleNumber : MonoBehaviour
{
    [SerializeField] List<int> _listOfNumbers;

    [Button("FIND the SINGLE NUMBER IN HTE ARRAY")]
    public void FindASingleNumber()
    {
        int result = 0;
        foreach (int num in _listOfNumbers)
        {
            result ^= num;
        }
        Debug.Log(result+"...SINGLE VALUE INT HE ARRAY");
    }

    [Button("REVERSE THE LIST")]
    public void ReverseTheList()
    {
        int left = 0;
        int right = _listOfNumbers.Count - 1;

        while (left < right)
        {
            int temp = _listOfNumbers[left];
            _listOfNumbers[left] = _listOfNumbers[right];
            _listOfNumbers[right] = temp;
            left++;
            right--;
        }
    }

    [Button("BINARY SEARCH")]
    public int SearchNumebrInTheArray(int targetNumebr)
    {
        int left = 0;
        int right = _listOfNumbers.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2; 

            if (_listOfNumbers[mid] == targetNumebr)
            {
                return mid; 
            }
            else if (_listOfNumbers[mid] < targetNumebr)
            {
                left = mid + 1; 
            }
            else
            {
                right = mid - 1; 
            }
        }

        return -1; 
    }
}
