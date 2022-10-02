using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornskinCardEffect : GuardCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.GainBlock(BlockValue);
        target.AddStatusEffect(new Thorns(target, 2));
    }
}
