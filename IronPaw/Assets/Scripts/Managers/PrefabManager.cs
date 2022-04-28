using UnityEngine;
using System;
using System.Collections.Generic;

public class PrefabManager : Singleton<PrefabManager>
{
    public GameObject PlainCardDispaly;
    public GameObject DamagePopup;

    public GameObject EffectSlot;
    
    
    public Sprite BleedIcon;


    public DropZone DropZone;

    Dictionary<Type, Sprite> StatusEffectDictionary = new Dictionary<Type, Sprite>();


    public Sprite GetSprite(StatusEffect StatusEffect)
    {
        switch (StatusEffect.StatusEffectType)
        {
            case StatusEffectType.Bleed:
                //
                return BleedIcon;
            case StatusEffectType.Taunt:
                //
                return BleedIcon;

            default:
                return BleedIcon;
        }
    }

    public void CreateDamagePopup(Vector3 pos, int amount)
    {
        DamagePopup popup = Instantiate(DamagePopup, pos, Quaternion.identity).GetComponent<DamagePopup>();
        popup.Setup(amount);
    }
}
