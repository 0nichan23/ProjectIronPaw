using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricSwipeCardEffect : AttackCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(CardDamage);
    }

}
