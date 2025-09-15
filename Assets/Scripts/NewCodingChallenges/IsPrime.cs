using NUnit.Framework.Internal;
using Sirenix.OdinInspector;
using System;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class IsPrime : MonoBehaviour
{
    [SerializeField] private int isPrimeNumber = 1;
    [SerializeField] private int isArmstrongNum = 1;

    [Button("Is Prime number")]
    public void CheckIsPrimeNu()
    {
        bool result = IsPrimeNumber(isPrimeNumber);
        if (result)
        {
            Debug.Log(isPrimeNumber + " is a prime number.");
        }
        else
        {
            Debug.Log(isPrimeNumber + " is not a prime number.");
        }
    }
    bool IsPrimeNumber(int num)
    {
        if (num <= 1) return false;
        if (num == 2 || num == 3) return true;

        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }

    [Button("Swapping two numbers without a third variable")]
    public void SwapTwoNu() //Bit was operatore convert nuumbers in decimal formate after it will do the calculation.
    {
        //Using Arithmetic (Addition & Subtraction)

        int a = 10, b = 20;

        a = a + b;  // a = 30
        b = a - b;  // b = 10
        a = a - b;  // a = 20

        Debug.Log($"Using Arithmetic a = {a}, b = {b}");

        // Using Arithmetic (Multiplication & Division)

        //int a = 10, b = 20;

        //a = a * b;  // a = 200
        //b = a / b;  // b = 10
        //a = a / b;  // a = 20

        //Debug.Log($"Using Arithmetic a = {a}, b = {b}");

        //Using Bitwise XOR(Best DSA Approach ⚡)

        //int a = 10, b = 20;

        //a = a ^ b;  // step 1
        //b = a ^ b;  // step 2
        //a = a ^ b;  // step 3

        //Debug.Log($" Bitwise XOR a = {a}, b = {b}");

    }

    //🔹 Interview Tip

    // * If interviewer asks for safe and reliable → use XOR method.

    // * If they ask for simple arithmetic trick → use addition/subtraction.

    //Interview Tip: You can also explain it using binary diagrams, like we did, to show you really understand the bitwise logic.


    public bool IsArmstrongNum(int num)
    {
        int originalNum = num;
        int length = originalNum.ToString().Length;
        int sum = 0;

        while (num > 0)
        {
            int digit = num % 10;//we will get last digit frm the number ==> 123 we get 3
            sum += (int)Math.Pow(digit, length);
            num /= 10;//Remove the last digit from the number ==> 123 we get 12
        }

        return sum == originalNum;
    }

    [Button("Is Armstrong number")]
    public void IsArmstrong()
    {
        bool result = IsArmstrongNum(isArmstrongNum);
        if (result)
        {
            Debug.Log(isArmstrongNum + " is a Armstrong number.");
        }
        else
        {
            Debug.Log(isArmstrongNum + " is not a Armstrong number.");
        }
    }

    //    An Armstrong number(also called narcissistic number) is a number that is equal to the sum of its digits raised to the power of the number of digits.

    //Example:

    //153 → 3 digits

    //1^3 + 5^3 + 3^3 = 1 + 125 + 27 = 153 \] ✅ Armstrong

    //9474 → 4 digits

    //9^4 + 4^4 + 7^4 + 4^4 = 9474 \] ✅ Armstrong
}
