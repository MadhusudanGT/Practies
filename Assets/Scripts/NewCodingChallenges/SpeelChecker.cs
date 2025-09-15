using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SpeelChecker : MonoBehaviour
{
    [SerializeField]
    private string[] wordlist = new string[] { "KiTe", "kite", "hare", "Hare" };

    [SerializeField]
    private string[] querys = new string[] { "kite", "Kite", "KiTe", "Hare", "HARE", "Hear", "hear", "keti", "keet", "keto" };

    [Button("Spell Checker")]
    public void SpellChecker()
    {
        Dictionary<string, string> _devowels = new Dictionary<string, string>();
        HashSet<string> _wordsList = new HashSet<string>(wordlist);
        Dictionary<string, string> _lowerCase = new Dictionary<string, string>();

        foreach (var word in wordlist)
        {
            string lowerCaseWord = word.ToLower();

            if (!_lowerCase.ContainsKey(lowerCaseWord))
            {
                _lowerCase[lowerCaseWord] = word;
            }

            string devowel = Devowel(word);
            if (!_devowels.ContainsKey(devowel))
            {
                _devowels[devowel] = word;
            }
        }
        //Debug.Log("DEVOWELS..." + String.Join(",", _devowels.Keys));
        //Debug.Log("LOWER CASE..." + String.Join(",", _lowerCase.Keys));

        var result = new List<string>();
        for (int i = 0; i < querys.Length; i++)
        {
            if (_wordsList.Contains(querys[i]))
            {
                result.Add(querys[i]);
            }
            else
            {
                string lower = querys[i].ToLower();
                if (_lowerCase.ContainsKey(lower))
                {
                    result.Add(_lowerCase[lower]);
                }
                else
                {
                    string deVowel = Devowel(querys[i]);
                    if (_devowels.ContainsKey(deVowel))
                    {
                        result.Add(_devowels[deVowel]);
                    }
                    else
                    {
                        result.Add("*");
                    }
                }
            }
        }

        Debug.Log("Result.." + string.Join(",", result));
    }

    string Devowel(string word)
    {
        char[] spiltChar = word.ToCharArray();
        for (int i = 0; i < spiltChar.Length; i++)
        {
            if (IsVowel(spiltChar[i]))
            {
                spiltChar[i] = '*';
            }
        }

        return new string(spiltChar);
    }

    bool IsVowel(char letter)
    {
        return "aeiou".Contains(char.ToLower(letter));
    }
}
