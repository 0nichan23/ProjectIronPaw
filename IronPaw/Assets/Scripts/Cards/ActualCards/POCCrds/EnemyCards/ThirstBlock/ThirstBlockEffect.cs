using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThirstBlock", menuName = "Cards/CardEffect/ColorlessCards/Attack/ThirstBlockEffect")]

public class ThirstBlockEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(DamageValue, playingCharacter, true));
        playingCharacter.GainBlock(1);
    }
}

