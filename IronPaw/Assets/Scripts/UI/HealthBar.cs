using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private TextMeshProUGUI HpText;

    public void UpdateHealthBar(int maxhp, int curhp)
    {
        slider.maxValue = maxhp;
        slider.value = curhp;
        HpText.text = curhp.ToString() + "/" + maxhp.ToString();
    }

}
