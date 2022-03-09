using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSo : ScriptableObject
{
    public string Title;
    public string Description;
    public Color[] Colors;
    public Rarity Rarity;
    public int ManaCost;
    CardEffect CardEffect;
    CardUI CardUI;
    public bool IsSwift;
    Sprite CardImage;
    CardType CardType;

    public void PlayCard(CharacterTEMP playingCharacter)
    {

    }
}
