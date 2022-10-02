using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraActionCardEffect : UtilityCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.MaxAp++;
        target.CurrentAp++;
    }
}
