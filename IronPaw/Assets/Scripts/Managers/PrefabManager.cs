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

    Dictionary<Type, Sprite> ModifierDictionary = new Dictionary<Type, Sprite>();


    public Sprite GetSprite(StatusEffect mod)
    {
        switch (mod.ModType)
        {
            case ModifierType.Bleed:
                //
                return BleedIcon;
            case ModifierType.Taunt:
                //
                return BleedIcon;

            default:
                return BleedIcon;
        }
    }
}
