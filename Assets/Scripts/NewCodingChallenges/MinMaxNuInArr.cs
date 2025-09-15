using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinMaxNuInArr : MonoBehaviour
{
    [SerializeField] int[] _listOfNumbers = new int[] { };

    [Button("Min And Max Number")]
    public void MinMaxNu()
    {
        if (_listOfNumbers.Length == 0)
        {
            Debug.Log("List of number was zero..");
            return;
        }

        int min = _listOfNumbers[0];
        int max = _listOfNumbers[_listOfNumbers.Length - 1];

        for (int i = 1; i < _listOfNumbers.Length; i++)
        {
            if (_listOfNumbers[i] < min)
                min = _listOfNumbers[i];

            if (_listOfNumbers[i] > max)
                max = _listOfNumbers[i];
        }

        Debug.Log("Min Number.." + min + "....Max Number..." + max);
    }

    [Button("Find Duplicates In Array")]
    public void FindDuplicates()
    {
        var result = _listOfNumbers.GroupBy(w => w).Where(g => g.Count() > 1);

        foreach (var i in result)
        {
            Debug.Log("Key.." + i.Key + "..Value.." + i.Count());
        }
    }

    [Button("Remove Duplicates In Array")]
    public void RemoveDuplicates()
    {
        var result = _listOfNumbers.GroupBy(w => w).Where(g => g.Count() == 1);

        foreach (var i in result)
        {
            Debug.Log("Key.." + i.Key + "..Value.." + i.Count());
        }
    }
}
