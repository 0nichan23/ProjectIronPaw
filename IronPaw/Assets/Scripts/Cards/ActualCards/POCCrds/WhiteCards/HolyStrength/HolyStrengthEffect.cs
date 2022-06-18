using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HolyStrengthEffect", menuName = "Cards/CardEffect/WhiteCards/Utility/HolyStrengthEffect")]

public class HolyStrengthEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.AddStat(StatType.STRENGTH, 3);
    }
}
