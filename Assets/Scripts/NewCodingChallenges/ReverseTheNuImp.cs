using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.tvOS;

public class ReverseTheNuImp : MonoBehaviour
{
    [SerializeField] private int reverseInt;

    [Button("REVERSE THE INTEGER")]
    public void ReverTheInteger()
    {
        int num = reverseInt;
        int reversed = 0;

        while (num != 0)
        {
            int digit = num % 10; // it's going to return me a last digit.
            Debug.Log("digit..."+ digit);
            reversed = reversed * 10 + digit; //help me to move the return digit to the first position.
            Debug.Log("reversed..." + reversed);
            num /= 10;//help me to get a remaing digits in the numbers
            Debug.Log("num..." + num);
            //Debug.Log(digit+"..."+ reversed+"..."+ num);
        }

        //Debug.Log($"Original: {reverseInt}, Reversed: {reversed}");
    }
}

/*
Step 4: Extract the Last Digit

int digit = num % 10;
We use modulus (%) operator to get the last digit of num.

Example:
If num = 123, 123 % 10 = 3 (last digit is 3).
If num = 45, 45 % 10 = 5 (last digit is 5).

🔹 Step 5: Build the Reversed Number

reversed = reversed * 10 + digit;
We shift the previous reversed value left by multiplying it by 10 and then add the extracted digit.
Example:
Initial reversed = 0, digit = 3 → reversed = 0 * 10 + 3 = 3
Next digit = 2 → reversed = 3 * 10 + 2 = 32
Next digit = 1 → reversed = 32 * 10 + 1 = 321

🔹 Step 6: Remove the Last Digit

num /= 10;
We remove the last digit from num using integer division (/). Example:
If num = 123, 123 / 10 = 12(removes 3).
If num = 12, 12 / 10 = 1 (removes 2).
If num = 1, 1 / 10 = 0 (loop stops).
*/