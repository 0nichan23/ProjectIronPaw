using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastStabCardEffect : AttackCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        Damage damage = new Damage(DamageValue + 2 * playingCharacter.Controller.TurnTracker.NumberOfCardsPlayed, playingCharacter, true);
        target.TakeDmg(damage);
    }
}
