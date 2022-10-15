using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolsterCardEffect : GuardCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.GainBlock(BlockValue);
        target.AddStatusEffect(new Taunt(target, 1));
    }
}
