using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BolsterEffect", menuName = "Cards/CardEffect/RedCards/Guard/BolsterEffect")]

public class BolsterEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        playingCharacter.GainBlock(7);
        playingCharacter.AddStatusEffect(new Taunt(playingCharacter, 1));
    }
}
