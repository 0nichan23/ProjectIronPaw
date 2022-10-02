using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDaggerCardEffect : AttackCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(CardDamage);
    }
}
