using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirstBlockCardEffect : AttackCardEffect
{
    private int _numberOfTargetsHit = 0;
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        int targetHealthBeforeAttack = target.CurrentHP + target.CurrentBlock;
        target.TakeDmg(CardDamage);
        if (target.CurrentHP < targetHealthBeforeAttack)
        {
            _numberOfTargetsHit++;
        }
    }

    protected override void OneTimeEffect(Character playingCharacter)
    {
        playingCharacter.GainBlock(_numberOfTargetsHit);
        _numberOfTargetsHit = 0;
    }
}
