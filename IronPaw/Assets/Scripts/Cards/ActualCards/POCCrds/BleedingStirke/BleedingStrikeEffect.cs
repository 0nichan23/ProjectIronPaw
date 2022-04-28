using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BleedingStrike", menuName = "Cards/CardEffect/ColorlessCards/Attack/BleedingStrikeEffect")]
public class BleedingStrikeEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(3, playingCharacter, true));
        target.AddStatusEffect(new Bleed(target, 3));
    }
}
