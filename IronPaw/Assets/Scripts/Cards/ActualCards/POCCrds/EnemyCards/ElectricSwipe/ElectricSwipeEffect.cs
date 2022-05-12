using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ElectricSwipe", menuName = "Cards/CardEffect/ColorlessCards/Attack/ElectricSwipeEffect")]

public class ElectricSwipeEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(DamageValue, playingCharacter, true));
        
    }
}
