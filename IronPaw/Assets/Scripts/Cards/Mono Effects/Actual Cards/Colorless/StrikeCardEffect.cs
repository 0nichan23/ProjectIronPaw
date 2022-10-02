using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeCardEffect : AttackCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(DamageValue, playingCharacter, true));
    }
}
