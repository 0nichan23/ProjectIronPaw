using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StrikeEffect", menuName = "Cards/CardEffect/ColorlessCards/Attack/StrikeEffect")]

public class StrikeEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(DamageValue, playingCharacter, true));
    }
}
