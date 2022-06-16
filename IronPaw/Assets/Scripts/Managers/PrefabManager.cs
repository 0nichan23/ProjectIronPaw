using System;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : Singleton<PrefabManager>
{
    public GameObject PlainCardDispaly;

    public GameObject EffectSlot;


    public Sprite BleedIcon;


    public DropZone DropZone;

    public List<Sprite> SpritesIcons = new List<Sprite>();

    Dictionary<Type, Sprite> StatusEffectDictionary = new Dictionary<Type, Sprite>();


    public List<Sprite> IntentionIcons = new List<Sprite>(3);

    [SerializeField] private List<Sprite> _cardFrames = new List<Sprite>();
    [SerializeField] private List<Sprite> _plateFrames = new List<Sprite>();
    [SerializeField] private List<Sprite> _rarityFrames = new List<Sprite>();
    [SerializeField] private List<Sprite> _typeFrames = new List<Sprite>();



    [SerializeField] public KeywordDisplayManager _keywordManager;

    public Sprite GetSprite(StatusEffect StatusEffect)
    {

        int index = (int)StatusEffect.StatusEffectType;


        return SpritesIcons[index - 1];
    }



    public Sprite GetIntentionTypeSprite(CardScriptableObject card)
    {
        switch (card.CardType)
        {
            case CardType.Attack:
                return IntentionIcons[0];


            case CardType.Guard:
                return IntentionIcons[1];

            case CardType.Utility:
                if (card.BuffType == UtilityBuffType.BUFF)
                {
                    return IntentionIcons[2];
                }
                else if(card.BuffType == UtilityBuffType.DEBUFF)
                {
                    return IntentionIcons[3];
                }
                return null;

            default:

                return null;
        }
    }

    public Sprite GetCardFrameByColor(List<string> colorID)
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

    public Sprite GetCardPlateFrameByColor(List<string> colorID)
    {
        foreach (var frame in _plateFrames)
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

    public Sprite GetCardRarityFrame(Rarity rarity)
    {
        return _rarityFrames[(int)rarity];
    }

    public Sprite GetCardTypeFrame(CardType cardType)
    {
        return _typeFrames[(int)cardType];
    }
}
