using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{

    [SerializeField] Slider slider;


    [SerializeField]
    TextMeshProUGUI HpText;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateHealthBar(int maxhp, int curhp)
    {
        slider.maxValue = maxhp;
        slider.value = curhp;
        HpText.text = curhp.ToString() + " / " + maxhp.ToString();
    }

}
