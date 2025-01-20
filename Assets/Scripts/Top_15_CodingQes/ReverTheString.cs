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

}
