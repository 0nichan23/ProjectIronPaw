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
    public int ManaCost;
    CardEffect CardEffect;
    public bool IsSwift;
    public Sprite Artwork;
    public CardType CardType;

    public void PlayCard(Character playingCharacter)
    {

    }

    //private void InstantiateCardDisplay()
    //{
        
    //}
}
