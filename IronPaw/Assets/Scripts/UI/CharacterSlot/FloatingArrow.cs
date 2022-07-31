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
    private float _elapsedTime;
    float _timeToFlick = 0.25f;

    private void Update()
    {
        if(_isDimming)
        {
            _elapsedTime -= Time.deltaTime;
            if(_elapsedTime < 0)
            {
                _isDimming = !_isDimming;
            }
           
        }
        else
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > _timeToFlick)
            {
                _isDimming = !_isDimming;
            }
        }

        
        //_arrowImage.color = Color.Lerp(_startColor, _targetColor, _elapsedTime);
        _arrowImage.color = Color.Lerp(_startColor, _targetColor, Mathf.PingPong(Time.time, 1));
    }
}
