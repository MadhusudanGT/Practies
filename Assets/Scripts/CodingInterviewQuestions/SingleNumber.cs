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

    [Button("PALINDROME")]
    public void CheckPalindrome()
    {
        int left = 0;
        int right = _listOfNumbers.Count - 1;

        while (left < right)
        {
            if (_listOfNumbers[left] == _listOfNumbers[right])
            {
                left++;
                right--;
            }
            else
            {
                Debug.Log("NOT A PALINDROME");
                return; 
            }
        }

        Debug.Log("GIVEN ARRAY WAS A PALINDROME");
    }
    [Button("LONGEST SUB STRING")]
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        int maxLength = 0;
        int start = 0;

        Dictionary<char, int> charIndexMap = new Dictionary<char, int>();

        for (int end = 0; end < s.Length; end++)
        {
            char currentChar = s[end];

            if (charIndexMap.ContainsKey(currentChar) && charIndexMap[currentChar] >= start)
            {
                start = charIndexMap[currentChar] + 1;
            }

            charIndexMap[currentChar] = end;

            maxLength = Mathf.Max(maxLength, end - start + 1);
         //   Debug.Log(start + "...." + end + "...." + currentChar + "..." + charIndexMap[currentChar] + "..." + maxLength);
        }

        return maxLength;
    }
}
