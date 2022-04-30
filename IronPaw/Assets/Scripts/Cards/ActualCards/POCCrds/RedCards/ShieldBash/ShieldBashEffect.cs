using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShieldBashEffect", menuName = "Cards/CardEffect/RedCards/Utility/ShieldBashEffect")]

public class ShieldBashEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(playingCharacter.CurrentBlock, playingCharacter, true));
    }
}
