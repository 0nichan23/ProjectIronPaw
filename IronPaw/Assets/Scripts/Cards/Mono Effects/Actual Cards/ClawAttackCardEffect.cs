using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawAttackCardEffect : AttackCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        base.PlayCardEffect(playingCharacter, target);
        target.TakeDmg(new Damage(DamageValue, playingCharacter, true));
    }
}
