using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/WhiteCards/Utility/RegenCardEffect")]
public class RegenTestEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        
        target.AddModifer(new Regen(target, 3));
    }
}
