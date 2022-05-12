using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DaggerThrowEffect", menuName = "Cards/CardEffect/GreenCards/Attack/DaggerThrowEffect")]

public class DaggerThrowEffect : CardEffect
{
    [SerializeField] private CardScriptableObject cardToCreate;

    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(DamageValue, playingCharacter, true));
        cardToCreate.GenerateCard(playingCharacter);
    }
}
