using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCanvas : MonoBehaviour
{
    [SerializeField] private Image _ultimateFillImage;
    [SerializeField] public ParticleSystem UltLightingParticleSystem;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = UIManager.Instance.MainCamera;
        UltLightingParticleSystem.transform.position = _mainCamera.ScreenToWorldPoint(_ultimateFillImage.transform.position);
    }
    public void FillUltimateChargeUI(float fill)
    {

        _ultimateFillImage.fillAmount = fill;
        if (fill == 1)
        {
            UltLightingParticleSystem.Play();
        }
        else
        {
            UltLightingParticleSystem.Stop();
        }
    }
}
