using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FastStabEffect", menuName = "Cards/CardEffect/GreenCards/Utility/FastStabEffect")]

public class FastStabEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        // need to imp dmg per card played + 2
        target.TakeDmg(new Damage(4, playingCharacter, true));
    }
}
