using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerateCardEffect : UtilityCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.AddStatusEffect(new Regen(target, 3));
    }
}
