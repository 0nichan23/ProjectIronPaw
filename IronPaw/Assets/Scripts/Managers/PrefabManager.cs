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

    public List<Sprite> SpritesIcons = new List<Sprite>();

    Dictionary<Type, Sprite> StatusEffectDictionary = new Dictionary<Type, Sprite>();


    public List<Sprite> CardTypeIcons = new List<Sprite>(3);

    [SerializeField] private List<Sprite> _cardFrames = new List<Sprite>();

    
    
    public Sprite GetSprite(StatusEffect StatusEffect)
    {
        
        int index = (int)StatusEffect.StatusEffectType;

        
        return SpritesIcons[index - 1];
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

    internal Sprite GetCardFrameByColor(List<string> colorID)
    {
        foreach (var frame in _cardFrames)
        {
            if (colorID.Count == 1)
            {
                if (frame.name == colorID[0])
                {
                    return frame;
                }
            }
            else if (colorID.Count == 2)
            {
                if (frame.name == colorID[0] + colorID[1] || frame.name == colorID[1] + colorID[0])
                {
                    return frame;
                }
            }            
        }

        throw new Exception("Invalid number of colors for a card!");
    }
}
