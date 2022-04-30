using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Roar", menuName = "Cards/CardEffect/ColorlessCards/Guard/RoarEffect")]

public class RoarEffectEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        playingCharacter.GainBlock(8);
        playingCharacter.AddStatusEffect(new Taunt(playingCharacter, 2));
            
    }
}
