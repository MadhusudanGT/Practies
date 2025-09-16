using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

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
        List<char> strings = new List<char>();
        StringBuilder sb = new StringBuilder();
        int count = 0;

        for (int i = 0; i < longestSubString.Length; i++)
        {
            if (!strings.Contains(longestSubString[i]))
            {
                strings.Add(longestSubString[i]);
            }
            else
            {
                if (sb.Length < string.Join("", strings).Length)
                {
                    sb.Clear();
                    sb.Append(string.Join("", strings));
                }

                strings.Clear();
                strings.Add(longestSubString[i]);
            }
        }
        Debug.Log(string.Join("", strings).Length > sb.Length ? $"Word => {string.Join("", strings)}, Count : {string.Join("", strings).Length}" : $"word : {sb}, count : {sb.Length}");
    }
}
