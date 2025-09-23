using Sirenix.OdinInspector;
using UnityEngine;

public class CompareVersions : MonoBehaviour
{
    [SerializeField] string verion1 = string.Empty;
    [SerializeField] string verion2 = string.Empty;

    [Button("Compare Strings")]
    public int CompareStringVersions()
    {
        string[] v1 = verion1.Split(".");
        string[] v2 = verion2.Split(".");

        int maxLength = Mathf.Max(v1.Length, v2.Length);
        for (int i = 0; i < maxLength; i++)
        {
            int num1 = i < v1.Length ? int.Parse(v1[i]) : 0;
            int num2 = i < v2.Length ? int.Parse(v2[i]) : 0;
            if (num1 > num2)
            {
                return 1;
            }
            if (num1 < num2)
            {
                return -1;
            }
        }
        return 0;
    }
}
