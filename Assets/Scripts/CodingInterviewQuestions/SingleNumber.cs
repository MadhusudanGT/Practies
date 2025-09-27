using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using UnityEngine;

public class SingleNumber : MonoBehaviour
{
    [SerializeField] List<int> _listOfNumbers;

    /// <summary>
    /// ^ operator means bitwise XOR when used with integers.
    /// bool isDifferent = (a ^ b) != 0;
    /// it returns 1 if the bits are different
    /// or returns 0 if they are the same.
    /// EX 1.Finding the single number in an array 2.Swapping two numbers. 3.Find Given Two Numbers are equal or not.
    /// </summary>

    [Button("FIND the SINGLE NUMBER IN HTE ARRAY")]
    public void FindASingleNumber()
    {
        int result = 0;
        foreach (int num in _listOfNumbers)
        {
            result ^= num;
        }
        Debug.Log(result + "...SINGLE VALUE INT HE ARRAY");
    }

    [Button("REVERSE THE LIST")]
    public void ReverseTheList()
    {
        int left = 0;
        int right = _listOfNumbers.Count - 1;

        while (left < right)
        {
            // Correct XOR swap
            _listOfNumbers[left] ^= _listOfNumbers[right];
            _listOfNumbers[right] ^= _listOfNumbers[left];
            _listOfNumbers[left] ^= _listOfNumbers[right];

            left++;
            right--;
        }

        Debug.Log("Reversed List: " + string.Join(", ", _listOfNumbers));
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
        int maxStart = 0; // store start index of max substring

        Dictionary<char, int> charIndexMap = new();

        for (int end = 0; end < s.Length; end++)
        {
            char currentChar = s[end];

            if (charIndexMap.ContainsKey(currentChar) && charIndexMap[currentChar] >= start)
            {
                start = charIndexMap[currentChar] + 1;
            }

            charIndexMap[currentChar] = end;

            if (end - start + 1 > maxLength)
            {
                maxLength = end - start + 1;
                maxStart = start; // track the start of max substring
            }
        }

        // Correct substring
        string subString = s.Substring(maxStart, maxLength);
        Debug.Log("Longest Substring: " + subString);
        return maxLength;
    }
}
