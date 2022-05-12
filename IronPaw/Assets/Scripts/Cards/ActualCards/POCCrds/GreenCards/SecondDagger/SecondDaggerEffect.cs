using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SecondDaggerEffect", menuName = "Cards/CardEffect/GreenCards/Attack/SecondDaggerEffect")]

public class SecondDaggerEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(DamageValue, playingCharacter, true));
    }
}
