using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CureEffect", menuName = "Cards/CardEffect/WhiteCards/Guard/CureEffect")]

public class CureEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.Heal(3, target);
        if (target)
        {

        }
    }
}
