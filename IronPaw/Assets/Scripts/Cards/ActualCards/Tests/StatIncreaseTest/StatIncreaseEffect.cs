using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/GreenCards/Utility/StatIncreaseEffect")]
public class StatIncreaseEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.Stats += new CharacterStats(0, 1, 0, 0);
        target.GainBlock(1);
    }
}
