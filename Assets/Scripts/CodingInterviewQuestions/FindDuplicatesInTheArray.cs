using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class FindDuplicatesInTheArray : MonoBehaviour
{
    [SerializeField] int[] nums;

    [Button("DUPLICATES IN HTE ARRAY")]
    public void FidnDuplicatesInTheArray()
    {
        int slow = nums[0];
        int fast = nums[0];

        do
        {
            Debug.Log(slow + "...SLOW....FAST..." + fast);
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        slow = nums[0];
        while (slow != fast)
        {
            Debug.Log(slow + "...SLOW......BEFORE....FAST..." + fast);
            slow = nums[slow];
            fast = nums[fast];
            Debug.Log(slow + "...SLOW....AFTER....FAST..." + fast);
        }
    }

    List<int> FindAllDuplicates(int[] nums)
    {
        HashSet<int> seen = new HashSet<int>();
        HashSet<int> duplicates = new HashSet<int>();

        foreach (int num in nums)
        {
            if (seen.Contains(num))
            {
                duplicates.Add(num);
            }
            else
            {
                seen.Add(num);
            }
        }

        return new List<int>(duplicates);
    }

    [Button("LIST OF DUPLICATES IN HTE ARRAY")]
    public void ListOfDup()
    {
        List<int> result = FindAllDuplicates(nums);
        Debug.Log(string.Join(",", result));
    }
}
