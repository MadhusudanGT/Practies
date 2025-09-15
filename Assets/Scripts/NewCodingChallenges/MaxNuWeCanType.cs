using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MaxNuWeCanType : MonoBehaviour
{
    [SerializeField] private string sentence = string.Empty;
    [SerializeField] private string missingKeys = string.Empty;

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


}
