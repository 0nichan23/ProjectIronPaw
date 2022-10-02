using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirstCardEffect : AttackCardEffect
{
    private int _numberOfTargetsHit = 0;
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        int targetHealthBeforeAttack = target.CurrentHP + target.CurrentBlock;
        target.TakeDmg(CardDamage);
        if(target.CurrentHP < targetHealthBeforeAttack)
        {
            _numberOfTargetsHit++;
        }
    }

    protected override void OneTimeEffect(Character playingCharacter)
    {
        playingCharacter.Heal(_numberOfTargetsHit, playingCharacter);
        _numberOfTargetsHit = 0;
    }
}
