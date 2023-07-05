using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortifyCardEffect : GuardCardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.GainBlock(10);

        foreach (var enemy in EnemyWrapper.Instance.EnemyController.ControllerChracters)
        {
            enemy.AddStatusEffect(new Weak(enemy, 1));
        }
    }
}
