using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class TwoPointers : MonoBehaviour
{
    [SerializeField] private List<int> _listOfArray;
    [SerializeField] private int target;

    public int[] SumTwoPoints(int[] numbers, int target)
    {
        int left = 0;
        int right = numbers.Length - 1;

        while (left < right)
        {
            int sum = numbers[left] + numbers[right];

            if (sum == target)
            {
                return new int[] { left + 1, right + 1 };
            }
            else if (sum < target)
            {
                left++; // Move the left pointer to increase the sum
            }
            else
            {
                right--; // Move the right pointer to decrease the sum
            }
        }

        Debug.LogError("No two numbers found that add up to the target.");
        return new int[0];
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
            Debug.Log($"Indices: {string.Join(", ", result)}");
        }
    }
}
