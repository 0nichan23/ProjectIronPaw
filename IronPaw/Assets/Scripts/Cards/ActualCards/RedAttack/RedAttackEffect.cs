using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/RedCards/Attacks/RedAttackEffect")]
public class RedAttackEffect : CardEffect
{


    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        Debug.Log("Heal for 5");
    }
}
