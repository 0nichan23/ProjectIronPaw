using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/ColorlessCards/TESTS/UIGOD")]

public class UITESTEFFECT : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        //target.AddStatusEffect(new Frail(target, 2));
        target.AddStatusEffect(new Weak(target, 2));
        //target.AddStatusEffect(new Bleed(target, 2));
        target.TakeDmg(new Damage(6, target));
        target.Heal(5, target);
    }
}
