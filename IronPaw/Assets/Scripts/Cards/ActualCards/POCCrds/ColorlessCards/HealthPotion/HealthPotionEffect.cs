using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotionEffect", menuName = "Cards/CardEffect/ColorlessCards/Utility/HealthPotionEffect")]

public class HealthPotionEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        playingCharacter.Heal(5, playingCharacter);
    }
}
