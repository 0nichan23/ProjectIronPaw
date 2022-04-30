using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefendEffect", menuName = "Cards/CardEffect/ColorlessCards/Guard/DefendEffect")]

public class DefendEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        playingCharacter.GainBlock(5);
    }
}
