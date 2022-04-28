using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSlot : MonoBehaviour
{
    //script to display character effects, hp, level etc.. 
    [SerializeField]
    Transform DisplayZone;

    List<StatusEffectSlot> statuses = new List<StatusEffectSlot>();


    public void DisplayEffect(StatusEffect StatusEffect)
    {
        GameObject NewEffect = Instantiate(PrefabManager.Instance.EffectSlot, DisplayZone.position, Quaternion.identity, DisplayZone);
        StatusEffectSlot newSlot = NewEffect.GetComponent<StatusEffectSlot>();
        newSlot.SetUp(StatusEffect);
        statuses.Add(newSlot);
    }

    public void UpdateStatuses()
    {
        foreach (var status in statuses)
        {
            status.UpdateStatusEffectUI();
        }
    }


    public void RemoveEffect(StatusEffect effect)
    {
        foreach (var item in statuses)
        {
            if (effect.StatusEffectType == item.myStatus.StatusEffectType)
            {
                statuses.Remove(item);
            }
        }
    }



    
}
