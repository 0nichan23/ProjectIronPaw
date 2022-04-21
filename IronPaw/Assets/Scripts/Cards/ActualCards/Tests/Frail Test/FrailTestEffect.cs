using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/RedCards/Attacks/FrailTestEffect")]
public class FrailTestEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        Debug.Log(target.CurrentHP);
        target.TakeDmg(new Damage(7, playingCharacter));
        Debug.Log(target.CurrentHP);
        target.AddStatusEffect(new Frail(target, 1));
    }
}
