using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FastStabEffect", menuName = "Cards/CardEffect/GreenCards/Attacks/FastStabEffect")]

public class FastStabEffect : CardEffect
{
    
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
       
        
        target.TakeDmg(new Damage(4+playingCharacter.Controller.TurnTracker.NumberOfCardsPlayed *2, playingCharacter, true));
    }
}
