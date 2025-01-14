using UnityEngine;
using Sirenix.OdinInspector;

public class Palindrome : MonoBehaviour
{
    [SerializeField] private string inputString =string.Empty;

    [Button("CHECK IS A PALINDROME")]
    public void IsPalindrome()
    {
        if(IsPalindrome(inputString)){
            Debug.Log("Input string was Palindrome..."+ inputString);
        }
		else
        {
            Debug.Log("Input string was not an Palindrome..." + inputString);
        }
    }

    bool IsPalindrome(string str)
    {
        if (string.IsNullOrEmpty(str))
            return false;

        int left = 0;
        int right = str.Length - 1;

        while (left < right)
        {
            while (left < right && !char.IsLetterOrDigit(str[left])) left++;
            while (left < right && !char.IsLetterOrDigit(str[right])) right--;

            if (char.ToLower(str[left]) != char.ToLower(str[right]))
                return false;

            left++;
            right--;
        }

        return true;
    }
}
