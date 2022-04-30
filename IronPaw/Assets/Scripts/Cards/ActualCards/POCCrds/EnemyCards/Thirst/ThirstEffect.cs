using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Thirst", menuName = "Cards/CardEffect/ColorlessCards/Attack/ThirstEffect")]

public class ThirstEffect : CardEffect
{
    
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        int targetsHit = Targets.Count;
        target.TakeDmg(new Damage(1, playingCharacter, true));
        target.Heal(targetsHit, playingCharacter);
    }
}
