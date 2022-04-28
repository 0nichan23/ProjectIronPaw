using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/ColorlessCards/Attack/EnemyRandomDamageEffect")]
public class EnemyRandomDamageEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(1, playingCharacter));
    }
}
