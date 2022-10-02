using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerThrowCardEffect : AttackCardEffect
{
    [SerializeField] private GameObject _secondDaggerCard;

    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(CardDamage);
        playingCharacter.AddStatusEffect(new AddSecondDaggerBuff(playingCharacter, 1, _secondDaggerCard));
    }
}
