using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBashCardEffect : AttackCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(playingCharacter.CurrentBlock, playingCharacter, true));
    }
}
