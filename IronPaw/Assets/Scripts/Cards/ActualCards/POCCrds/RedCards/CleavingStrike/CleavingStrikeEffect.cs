using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CleavingStrikeEffect", menuName = "Cards/CardEffect/RedCards/Attack/CleavingStrikeEffect")]

public class CleavingStrikeEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(10, playingCharacter, true));
        if (target.CurrentHP == 0)
        {
            
        }
    }
}
