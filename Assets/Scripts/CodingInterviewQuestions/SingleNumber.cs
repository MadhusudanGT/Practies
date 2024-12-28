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
}
