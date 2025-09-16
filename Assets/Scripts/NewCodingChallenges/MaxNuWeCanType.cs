using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.Windows;

public class MaxNuWeCanType : MonoBehaviour
{
    [SerializeField] private string sentence = string.Empty;
    [SerializeField] private string missingKeys = string.Empty;
    [SerializeField] private string longestSubString = string.Empty;

    [Button("Word Type without Keyboard")]
    public void FindNuOfWordCanType()
    {
        HashSet<char> keys = new HashSet<char>(missingKeys);
        string[] words = sentence.Split(' ');
        int count = 0;

        for (int i = 0; i < words.Length; i++)
        {
            bool canType = true;
            foreach (char item in words[i])
            {
                if (keys.Contains(item))
                {
                    canType = false;
                }
            }
            Debug.Log(words[i] + "...Keyss..." + canType);
            if (canType) { count++; }
        }
        Debug.Log("Count..." + count);
    }

    [Button("Longest Sub String !!")]
    public void LongestSubString()
    {
        Dictionary<char, int> map = new Dictionary<char, int>();
        int left = 0, maxLen = 0;
        string result = "";

        for (int right = 0; right < longestSubString.Length; right++)
        {
            char c = longestSubString[right];
            if (map.ContainsKey(c) && map[c] >= left)
            {
                Debug.Log(map[c] + ".." + c);
                left = map[c] + 1; // move left past duplicate
            }


            map[c] = right;

            if (right - left + 1 > maxLen)
            {
                maxLen = right - left + 1;
                result = longestSubString.Substring(left, maxLen);
            }
        }

        Debug.Log($"Longest substring: {result} ... Length: {maxLen}");
        (int length, string substring) = LongestSubString(longestSubString);
        Debug.Log($"Input: {longestSubString}, Longest substring: {substring}, Length: {length}");
    }

    public (int, string) LongestSubString(string s)
    {
        HashSet<char> set = new HashSet<char>();
        int maxLength = 0;
        int start = 0, end = 0;
        int bestStart = 0; // store starting index of the best substring

        while (end < s.Length)
        {
            char currentChar = s[end];

            if (!set.Contains(currentChar))
            {
                set.Add(currentChar);

                if (end - start + 1 > maxLength)
                {
                    maxLength = end - start + 1;
                    bestStart = start;
                }
                end++;
            }
            else
            {
                set.Remove(s[start]);
                start++;
            }
        }

        string longestSubstring = s.Substring(bestStart, maxLength);
        return (maxLength, longestSubstring);
    }
}
