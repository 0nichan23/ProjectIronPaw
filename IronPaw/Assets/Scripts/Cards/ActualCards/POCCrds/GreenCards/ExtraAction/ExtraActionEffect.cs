using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExtraActionEffect", menuName = "Cards/CardEffect/GreenCards/Utility/ExtraActionEffect")]

public class ExtraActionEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.MaxAp++;
        target.CurrentAp++;
    }
}
