using ModestTree;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class StringCodingInterview : MonoBehaviour
{
    [SerializeField] string str = string.Empty;

    [Button("Revers The String")]
    public void ReversTheString()
    {
        StringBuilder sb = new StringBuilder();

        string[] arr = str.Split(" ").ToArray();

        for (int i = 0; i < arr.Length; i++)
        {
            sb.Append(ReverseIt(arr[i]));
            sb.Append(" ");
        }
        Debug.Log(str + "...Reverse The String..." + sb);
    }

    string ReverseIt(string str)
    {
        return new string(str.Reverse().ToArray());
    }

    [Button("FindDuplicatesLinq")]
    public void FindDuplicatesLinq()
    {
        string str = "programming";
        int[] arr = new int[26];

        var duplicates = str
            .Where(c => c != ' ')
            .GroupBy(c => c)
            .Where(g => g.Count() > 0)
            .Select(g => new { Char = g.Key, Count = g.Count() });

        //foreach (var d in duplicates)
        //{
        //    Debug.Log($"Character '{d.Char}' appears {d.Count} times.");
        //}

        foreach (char c in str)
        {
            if (c > 'a' && c < 'z')
            {
                arr[c - 'a']++;
            }
        }

        for (int i = 0; i < 26; i++)
        {
            if (arr[i] > 1)
                Debug.Log($"Character '{(char)(i + 'a')}' appears {arr[i]} times.");
        }
    }

    [SerializeField] string input1 = "C# is my favorite language";
    [SerializeField] string input2 = "favorite my c# language is";

    [Button("Anagram")]
    public void CheckTheAnagram()
    {
        // Normalize: remove spaces and convert to lowercase
        string str1 = input1.ToLower().Replace(" ", "");
        string str2 = input2.ToLower().Replace(" ", "");

        if (str1.Length != str2.Length)
        {
            Debug.Log("Not an anagram (different lengths)");
            return;
        }

        // Count frequency of characters
        Dictionary<char, int> freq = new Dictionary<char, int>();

        foreach (char c in str1)
        {
            if (freq.ContainsKey(c))
                freq[c]++;
            else
                freq[c] = 1;
        }

        foreach (char c in str2)
        {
            if (!freq.ContainsKey(c))
            {
                Debug.Log("Not an anagram (char mismatch)");
                return;
            }

            freq[c]--;
            if (freq[c] == 0)
                freq.Remove(c);
        }

        Debug.Log(freq.Count == 0 ? "Is an anagram ✅" : "Not an anagram ❌");
    }

    [Button("Duplicate Word In Sentence")]
    public void DuplicateWordsInSentence()
    {
        Dictionary<string, int> output = str.Split(' ').GroupBy(w => w).ToDictionary(d => d.Key, d => d.Count());

        foreach (KeyValuePair<string, int> word in output)
        {
            Debug.Log(word.Key + "..." + word.Value);
        }
    }

    [Button("Count Number of words in the sentence")]
    public void CountNumberOfWords()
    {
        int words = str.Split(' ').Count();
        Debug.Log($"Total Words in the sentence ..." + words);
    }

    [Button("Unique Char in the string")]
    public void UniqueChar()
    {
        bool[] unique = new bool[128];
        for (int i = 0; i < str.Length; i++)
        {
            char item = str[i];
            if (!unique[item])
            {
                unique[item] = true;
                Debug.Log("Unique Char ..." + item);
            }
        }
    }


    [SerializeField] string swapStr1 = string.Empty;
    [SerializeField] string swapStr2 = string.Empty;

    [Button("Swap Number without using third variable")]
    public void SwapString()
    {
        swapStr1 = string.Concat(swapStr1, swapStr2);
        int len = swapStr1.Length - swapStr2.Length;
        Debug.Log("..swapStr1..." + swapStr1 + "..count..." + len);
        swapStr2 = swapStr1.Substring(0, len);
        swapStr1 = swapStr1.Substring(swapStr2.Length);
        Debug.Log("..swapStr1..." + swapStr1 + "..swapStr2..." + swapStr2);
    }
}
