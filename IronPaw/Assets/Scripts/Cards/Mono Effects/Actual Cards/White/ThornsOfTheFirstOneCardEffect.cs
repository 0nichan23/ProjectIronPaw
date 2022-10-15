using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsOfTheFirstOneCardEffect : UtilityCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.AddStatusEffect(new Thorns(target, 3));
    }
}
