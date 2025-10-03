using Sirenix.OdinInspector;
using System.Text;
using UnityEngine;

public class IntegertoRoman : MonoBehaviour
{
    [SerializeField] int intToRom = 0;
    [Button("int to roman converotr...")]
    public void ConvertIntToRom()
    {
        int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < values.Length && intToRom > 0; i++)
        {
            while (intToRom >= values[i])
            {
                intToRom -= values[i];
                sb.Append(symbols[i]);
            }
        }

        Debug.Log("Integer to Roman Convertor.." + sb.ToString());
    }
}
