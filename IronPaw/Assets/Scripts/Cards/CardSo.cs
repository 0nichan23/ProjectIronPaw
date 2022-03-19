using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class CardSO : ScriptableObject
{
    public string CardName;
    public string Description;
    public Color[] Colors;
    public Rarity Rarity;
    public int EnergyCost;
    [SerializeField]
    public CardEffect CardEffect;
    public bool IsSwift;
    public Sprite Artwork;
    public CardType CardType;

    public void PlayCard(Character playingCharacter)
    {

        if (CheckCardAndHeroColors(playingCharacter))
        {
            if(PlayerController.CurrentEnergy >= EnergyCost)
            {
                if (playingCharacter.CurrentAp >= 1 || IsSwift)
                {
                    PartyManager.Instance.PickTargets(playingCharacter, this);
              
                    if (!IsSwift)
                    {
                        playingCharacter.CurrentAp--;
                    }

                }
            }
        }
    }


    private bool CheckCardAndHeroColors(Character playingCharacter)
    {
        foreach (Color heroColor in playingCharacter.Colors)
        {
            foreach (var cardColor in Colors)
            {
                if (heroColor == cardColor)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
