using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/ColorlessCards/Utility/TestPotionEffect")]
public class TestPotionEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.Heal(5, target);

        Debug.Log("Potion Drank");
    }
}
