using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingArrow : MonoBehaviour
{
    [SerializeField] private Image _arrowImage;

    private bool _isDimming;

    [SerializeField] private Color _startColor;
    [SerializeField] private Color _targetColor;

    [SerializeField] private float _timeToFlick;

    private void Update()
    {        
        _arrowImage.color = Color.Lerp(_startColor, _targetColor, Mathf.PingPong(Time.time, _timeToFlick));
    }
}
