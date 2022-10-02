using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillBreakCardEffect : UtilityCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.AddStatusEffect(new Weak(target, 2));
    }
}
