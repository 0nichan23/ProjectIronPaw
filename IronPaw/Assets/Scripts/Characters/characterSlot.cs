using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterSlot : MonoBehaviour
{
    //script to display character effects, hp, level etc.. 
    Canvas PersonalCanvas;

    private void Start()
    {
        PersonalCanvas = GetComponentInChildren<Canvas>();
    }

    public void DisplayEffect()
    {
        GameObject NewEffect = Instantiate(PrefabManager.Instance.EffectSlot, PersonalCanvas.transform.position, Quaternion.identity);
        NewEffect.transform.SetParent(PersonalCanvas.transform);        
    }





    
}
