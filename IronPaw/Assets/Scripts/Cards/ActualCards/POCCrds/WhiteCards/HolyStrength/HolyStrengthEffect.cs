using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HolyStrengthEffect", menuName = "Cards/CardEffect/WhiteCards/Utility/HolyStrengthEffect")]

public class HolyStrengthEffect : CardEffect
{
   
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.Stats += new CharacterStats(3, 0, 0, 0);
    }
}
