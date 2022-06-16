using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Thirst", menuName = "Cards/CardEffect/ColorlessCards/Attack/ThirstEffect")]

public class ThirstEffect : CardEffect
{
    
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    { 
        target.TakeDmg(new Damage(DamageValue, playingCharacter, true));
        playingCharacter.Heal(1, playingCharacter);
    }
}
