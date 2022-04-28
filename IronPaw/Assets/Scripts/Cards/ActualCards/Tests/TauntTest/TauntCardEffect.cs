using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/RedCards/Attacks/TauntCardEffect")]
public class TauntCardEffect : CardEffect
{

    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {

        playingCharacter.AddStatusEffect(new Taunt(playingCharacter, 2));

        Debug.Log(target + " has Taunt");
}
}
