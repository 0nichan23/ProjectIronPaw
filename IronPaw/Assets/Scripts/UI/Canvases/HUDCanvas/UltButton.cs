using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltButton : MonoBehaviour
{
    [SerializeField] private Image _ultimateFillImage;
    [SerializeField] public ParticleSystem UltLightingParticleSystem;
    private Camera _mainCamera;
    private Coroutine _runningCoroutine;
    private void Start()
    {
        _mainCamera = UIManager.Instance.MainCamera;
        UltLightingParticleSystem.transform.position = _mainCamera.ScreenToWorldPoint(_ultimateFillImage.transform.position);
    }
    public void FillUltimateChargeUI(float fill)
    {
        //StopCoroutine(_runningCoroutine);
        _runningCoroutine = StartCoroutine(SlowlyFillUltimateChargeUI(fill));

        //_ultimateFillImage.fillAmount = fill;

        //if (fill == 1)
        //{
        //    UltLightingParticleSystem.Play();
        //}
        //else
        //{
        //    UltLightingParticleSystem.Stop();
        //}
    }

    private IEnumerator SlowlyFillUltimateChargeUI(float fill)
    {
        if (_ultimateFillImage.fillAmount < fill)
        {
            while (_ultimateFillImage.fillAmount < fill)
            {
                _ultimateFillImage.fillAmount += Time.deltaTime;
                yield return null;
            }
        }
        else if (_ultimateFillImage.fillAmount > fill)
        {
            while (_ultimateFillImage.fillAmount > fill)
            {
                _ultimateFillImage.fillAmount -= Time.deltaTime;
                yield return null;
            }
        }

        _ultimateFillImage.fillAmount = fill;
    }
}
