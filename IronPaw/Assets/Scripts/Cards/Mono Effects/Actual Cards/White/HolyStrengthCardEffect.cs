using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyStrengthCardEffect : UtilityCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.AddStat(StatType.STRENGTH, 3);
    }
}
