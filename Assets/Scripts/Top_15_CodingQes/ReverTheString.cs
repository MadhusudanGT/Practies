using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class ReverTheString : MonoBehaviour
{
    [SerializeField] int givenString = 0;

    [Button("CHECK FOR REVER THE STRING")]
    public int CheckForGivenStringWasReverse()
    {
        if (givenString == int.MinValue)
            return 0;

        bool isNegative = givenString < 0;
        givenString = Mathf.Abs(givenString);

        char[] charArray = givenString.ToString().ToCharArray();
        Array.Reverse(charArray);
        string reversedString = new string(charArray);

        if (int.TryParse(reversedString, out int reversed))
        {
            return isNegative ? -reversed : reversed;
        }
        else
        {
            return 0;
        }
    }

    [SerializeField] int[] arr;

    [Button("REMOVE DUPLICATES FROM THE ARRAY")]
    public void RemoveDuplicates() //Two-pointer technique
    {
        if (arr.Length == 0)
        {
            Debug.Log("No Elements Found!");
            return;
        }

        int index = 1;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] != arr[i - 1])
            {
                arr[index] = arr[i];
                index++;
            }
        }
        Debug.Log(index);
    }


    [SerializeField] int[] swapZeros;
    [Button("Move all 0’s to the end while maintaining the order of non-zero elements.")]
    public void SwapZeroToTheEnd()//Two-pointer technique, in-place swapping
    {
        int index = 0;
        for (int i = 0; i < swapZeros.Length; i++)
        {
            if (swapZeros[i] != 0)
            {
                (swapZeros[i], swapZeros[index]) = (swapZeros[index], swapZeros[i]);
                index++;
            }   
        }
    }



    [Button("reverse the array")]
    public void ReversIt(int k)
    {
        ReverseTheArray(swapZeros, 0,k-1);
    }

    private void ReverseTheArray(int[] nums, int left, int right)
    {
        while (left < right)
        {
            (nums[left], nums[right]) = (nums[right], nums[left]);
            left++;
            right--;
        }
    }
}
