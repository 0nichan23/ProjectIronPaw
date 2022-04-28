using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShieldOfTheAncients", menuName = "Cards/CardEffect/ColorlessCards/Guard/ShieldOfTheAncientsEffect")]

public class ShieldOfTheAncientsEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        playingCharacter.AddStatusEffect(new Immune(playingCharacter, 1));
    }
}
