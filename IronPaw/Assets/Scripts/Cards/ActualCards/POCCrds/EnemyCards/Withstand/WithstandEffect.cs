using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Withstand", menuName = "Cards/CardEffect/ColorlessCards/Guard/Withstand")]
public class WithstandEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        playingCharacter.GainBlock(8);
    }
}
