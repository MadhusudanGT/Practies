using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Linq;

public class MaxChankToSorted : MonoBehaviour
{
    [SerializeField] List<int> _listOfNumbers;
    [Space]
    [SerializeField] string s1;
    [SerializeField] string s2;
    [Header("Not Matched Words from s1 , s2")]
    [SerializeField] List<string> _listOfWords;

    [Button("MaxChankToSorted")]
    public void SortMaxChank()
    {
        int runningSum = 0, expectedSum = 0, chunks = 0;

        for (int i = 0; i < _listOfNumbers.Count; i++)
        {
            runningSum += _listOfNumbers[i];
            expectedSum += i;
            if (runningSum == expectedSum)
            {
                chunks++;
            }

            Debug.Log(runningSum + "...." + expectedSum + "....." + chunks);
        }
    }


    [Button("MATCHING WORDS IN TWO STRING ")]
    public void MatchingWords()
    {//we can make this more better
        _listOfWords.Clear();

        string[] sentence1 = s1.Split(' ');
        string[] sentence2 = s2.Split(' ');

        for (int i = 0; i < sentence1.Length; i++)
        {
            if (!sentence2.Contains(sentence1[i]) && sentence1.Count(w => w == sentence1[i]) == 1) 
            {
                _listOfWords.Add(sentence1[i]);
            }
        }

        for (int i = 0; i < sentence2.Length; i++)
        {
            if (!sentence1.Contains(sentence2[i]) && sentence2.Count(w => w == sentence2[i]) == 1)
            {
                _listOfWords.Add(sentence2[i]);
            }
        }
    }


}
