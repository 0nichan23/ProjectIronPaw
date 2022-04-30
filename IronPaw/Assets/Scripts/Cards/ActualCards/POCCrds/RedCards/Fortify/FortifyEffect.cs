using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FortifyEffect", menuName = "Cards/CardEffect/RedCards/Guard/FortifyEffect")]

public class FortifyEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        playingCharacter.GainBlock(10);
        playingCharacter.AddStatusEffect(new Weak(playingCharacter, 1));
    }
}
