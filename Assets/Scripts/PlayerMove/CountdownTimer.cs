using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float _countDownTime = 120f; 
    private float _initTimer;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _initTimer = _countDownTime;
    }

    private void Update()
    {
        _initTimer -= Time.deltaTime;

        if (_initTimer <= 0)
        {
            _initTimer = 0;
        }

        _text.text = "Time: " + Mathf.Ceil(_initTimer).ToString();
    }
    [Button("RESET TIMER")]
    public void ResetTimer()
    {
        _initTimer = _countDownTime;
    }
}
