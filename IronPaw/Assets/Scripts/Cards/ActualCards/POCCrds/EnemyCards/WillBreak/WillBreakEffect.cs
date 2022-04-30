using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WillBreakEffect", menuName = "Cards/CardEffect/ColorlessCards/Utility/WillBreakEffect")]

public class WillBreakEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.AddStatusEffect(new Weak(target, 2));
    }
}
