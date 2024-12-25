using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Linq;
using System;

public class MissingNumebrs : MonoBehaviour
{
    [SerializeField] List<int> _missingNuList;

    //Performance: Using a HashSet makes lookups faster (O(1) average case) compared to List (O(n) average case).

    [Button("MISSING NUMBERS")]
    public void FoundMissingNumbers()
    {
        if (_missingNuList == null || _missingNuList.Count == 0)
        {
            Debug.Log("LIST WAS EMPTY");
            return;
        }

        HashSet<int> numset = new HashSet<int>(_missingNuList);
        int n = _missingNuList.Count;

        // Check if `n` is missing
        if (!numset.Contains(n))
        {
            Debug.Log("MISSING INDEX WAS " + n);
        }

        // Check for missing numbers in the range [0, n-1]
        for (int i = 0; i < n; i++)
        {
            if (!numset.Contains(i))
            {
                Debug.Log("MISSING INDEX WAS " + i);
            }
        }
    }

}
