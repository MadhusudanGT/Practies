using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class permutations : MonoBehaviour
{
    [Button("permutations")]
    public void FindPermutations(string str)
    {
        List<string> results = new List<string>();
        Permute(str.ToCharArray(), 0, str.Length - 1, results);

        foreach (var perm in results)
        {
            Debug.Log(perm);
        }
    }

    private void Permute(char[] chars, int left, int right, List<string> results)
    {
        if (left == right)
        {
            results.Add(new string(chars));
        }
        else
        {
            for (int i = left; i <= right; i++)
            {
                Swap(ref chars[left], ref chars[i]);
                Permute(chars, left + 1, right, results);
                Swap(ref chars[left], ref chars[i]);
            }
        }
    }

    private void Swap(ref char a, ref char b)
    {
        char temp = a;
        a = b;
        b = temp;
    }

    [SerializeField]
    int[] arry = { 5, 2, 1, 3, 6, 4 };

    [Button("Sort without Inbuild Func")]
    public void SortTheArry()
    {
        
    }
}
