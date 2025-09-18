using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class TwoPointers : MonoBehaviour
{
    [SerializeField] private List<int> _listOfArray;
    [SerializeField] private int target;

    public int[] SumTwoPoints(int[] numbers, int target)
    {
        Dictionary<int, int> result = new Dictionary<int, int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            int total = target - numbers[i];

            if (result.ContainsKey(total))
            {
                return new int[] { result[total], i };
            }

            if (!result.ContainsKey(total))
            {
                result.Add(numbers[i], i);
            }
        }
        return new int[] { };
    }

    [Button("SUM OF THE TWO TARGET VALUES")]
    public void CalSumOfTwoPoints()
    {
        if (_listOfArray == null || _listOfArray.Count == 0)
        {
            Debug.LogError("The list is empty or null.");
            return;
        }

        int[] arr = _listOfArray.ToArray();

        int[] result = SumTwoPoints(arr, target);

        if (result.Length > 0)
        {
            int sum = 0;
            for (int i = 0; i < result.Length; i++)
            {
                sum += _listOfArray[result[i]];
            }
            Debug.Log("Total Sum Match WIth the target..." + sum + "..Index was.." + string.Join(",", result));
        }
    }
}
