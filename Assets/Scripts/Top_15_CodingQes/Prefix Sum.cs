using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class PrefixSum : MonoBehaviour
{
    [SerializeField] int[] _prefixListNu;
    [SerializeField] int _start;
    [SerializeField] int _end;

    public int[] CreatePrefixSumArray(int[] nums)
    {
        int[] prefixSum = new int[nums.Length];
        prefixSum[0] = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + nums[i];
        }
        return prefixSum;
    }

    public int RangeSum(int[] prefixSum, int i, int j)
    {
        if (i == 0) return prefixSum[j];
        //Debug.Log(prefixSum[i - 1]+ "...i......j..." + prefixSum[j]);
        return prefixSum[j] - prefixSum[i - 1];
    }

    [Button("PREFIX SUM")]
    public void FindPreFixSum()
    {
        if (_prefixListNu.Length <= 0) 
        {
            //Debug.Log("PreFixListNu Length Was Zero..");
            return;
        }

        if (_end >= _prefixListNu.Length)
        {
            //Debug.Log("OutOfBound Exception check the end number must be below the _prefix length");
            return;
        }

        int[] result = CreatePrefixSumArray(_prefixListNu);

        int preFixSum = RangeSum(result, _start, _end);
        Debug.Log(string.Join(",", result)+"...."+ preFixSum);
    }

}
