using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThornskinEffect", menuName = "Cards/CardEffect/ColorlessCards/Guard/ThornskinEffect")]

public class ThornskinEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        playingCharacter.GainBlock(5);
        playingCharacter.AddStatusEffect(new Thorns(playingCharacter, 2, 0));

    }
}
