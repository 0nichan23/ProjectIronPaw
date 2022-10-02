using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakleCardEffect : AttackCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(CardDamage);
        target.AddStatusEffect(new Frail(target, 2));
    }
}
