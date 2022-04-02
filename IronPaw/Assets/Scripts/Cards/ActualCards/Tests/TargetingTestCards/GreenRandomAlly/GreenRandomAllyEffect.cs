using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/GreenCards/Utility/GreenRandomAllyEffect")]
public class GreenRandomAllyEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter)
    {
        Character charCache = Targets[0];

        Debug.Log(charCache.CharacterName + " has " + charCache.CurrentHP + " health ");
        charCache.GainBlock(3);
        Debug.Log(charCache.CharacterName + " has " + charCache.CurrentHP + " health ");
    }

   
}
