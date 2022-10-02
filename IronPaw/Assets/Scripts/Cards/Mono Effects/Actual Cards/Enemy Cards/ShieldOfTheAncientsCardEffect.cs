using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOfTheAncientsCardEffect : GuardCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.AddStatusEffect(new Immune(target, 1));
    }
}
