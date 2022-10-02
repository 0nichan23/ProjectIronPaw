using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithstandCardEffect : GuardCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.GainBlock(BlockValue);
    }
}
