using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidCardEffect : UtilityCardEffect
{
    [SerializeField] private int _amountToHeal;

    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.Heal(_amountToHeal, playingCharacter);
    }
}
