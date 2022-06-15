using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThornsOfTheFirstOneEffect", menuName = "Cards/CardEffect/WhiteCards/Utility/ThornsOfTheFirstOneEffect")]

public class ThornsOfTheFirstOneEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.AddStatusEffect(new Thorns(target, 3));
    }
}
