using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ThornsOfTheFirstOneEffect", menuName = "Cards/CardEffect/TESTS/WhiteCards/Utility/uitestcard")]

public class UITESTEFFECT : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(DamageValue, playingCharacter, true));
        target.AddStatusEffect(new Frail(target, 2));
        target.AddStatusEffect(new Weak(target, 2));
        target.AddStatusEffect(new Frail(target, 2));
        target.GainBlock(6);
    }
}
