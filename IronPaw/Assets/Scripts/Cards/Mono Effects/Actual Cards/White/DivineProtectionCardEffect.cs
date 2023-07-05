using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivineProtectionCardEffect : GuardCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.GainBlock(BlockValue);
    }
}
