using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleavingStrikeCardEffect : AttackCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(DamageValue, playingCharacter, true));
        if (target.CurrentHP <= 0)
        {
            playingCharacter.CurrentAp++;
            if (playingCharacter is Hero)
            {
                ((playingCharacter.Controller) as PlayerController).CurrentEnergy++;
            }

        }
    }
    
}
