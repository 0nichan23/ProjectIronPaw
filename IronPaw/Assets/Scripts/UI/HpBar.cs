using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBar : MonoBehaviour
{
    Slider slider;


    
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }


    public void SetUpOrUpdateBar(int maxhp, int curhp)
    {
        /*if (slider  == null)
        {
            return;
        }*/
        slider.maxValue = maxhp;
        slider.value = curhp;
    }
}
