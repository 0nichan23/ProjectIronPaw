using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterSlot : MonoBehaviour
{
    //script to display character effects, hp, level etc.. 
    [SerializeField]
    Transform DisplayZone;


    public void DisplayEffect(StatusEffect mod)
    {
        GameObject NewEffect = Instantiate(PrefabManager.Instance.EffectSlot, DisplayZone.position, Quaternion.identity, DisplayZone);
        NewEffect.GetComponent<Image>().sprite = PrefabManager.Instance.GetSprite(mod);
    }





    
}
