using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackCardEffect : AbstractCardEffect
{
    public int DamageValue;
    public Damage CardDamage;

    public override void InitializePlayEffect(Character playingCharacter)
    {
        base.InitializePlayEffect(playingCharacter);
        CardDamage = new Damage(DamageValue, playingCharacter, true);
    }
    

    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {

    }
}
