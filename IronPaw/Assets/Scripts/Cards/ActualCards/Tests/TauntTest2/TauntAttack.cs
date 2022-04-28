using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/RedCards/Attacks/TauntAttack")]
public class TauntAttack : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(1, playingCharacter));
        target.AddStatusEffect(new Taunt(target, 3));
    }
}
