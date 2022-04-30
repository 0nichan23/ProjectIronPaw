using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RegenerateEffect", menuName = "Cards/CardEffect/Red&WhiteCards/Utility/RegenerateEffect")]

public class RegenerateEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.Heal(3, target);
        target.AddStatusEffect(new Regen(target, 3));
    }
}
