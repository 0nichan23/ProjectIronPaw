using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClawAttack", menuName = "Cards/CardEffect/ColorlessCards/Attack/ClawAttackEffect")]
public class ClawAttackEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(7, playingCharacter, true));
    }
}

