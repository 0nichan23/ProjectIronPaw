using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedingStrikeCardEffect : AttackCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(CardDamage);
        target.AddStatusEffect(new Bleed(target, 3));
    }
}
