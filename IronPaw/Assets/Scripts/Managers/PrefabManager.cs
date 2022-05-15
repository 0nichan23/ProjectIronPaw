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


    public List<Sprite> CardTypeIcons = new List<Sprite>(3);

    
    
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

    public Sprite GetIntentionTypeSprite(CardScriptableObject card)
    {
        switch (card.CardType)
        {
            case CardType.Attack:
                return CardTypeIcons[0];
                
                
            case CardType.Guard:
                return CardTypeIcons[1];

            case CardType.Utility:
                return CardTypeIcons[2];

            default:

                return null;
        }
    }

   
}
