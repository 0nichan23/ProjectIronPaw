using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/GreenCards/Attacks/GreenRandomEnemyEffect")]
public class GreenRandomEnemyEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter)
    {
        Character charCache = Targets[0];

        Debug.Log(charCache.CharacterName + " has " + charCache.CurrentHP + " health ");
        charCache.TakeDmg(new Damage(6, playingCharacter));
        Debug.Log(charCache.CharacterName + " has " + charCache.CurrentHP + " health ");
    }
}
