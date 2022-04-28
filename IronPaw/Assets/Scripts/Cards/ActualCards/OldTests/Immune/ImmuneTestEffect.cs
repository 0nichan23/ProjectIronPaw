using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/RedCards/Utility/ImmuneTestEffect")]
public class ImmuneTestEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        Debug.Log(target.CurrentHP);
        target.TakeDmg(new Damage(1, playingCharacter, false));
        target.AddStatusEffect(new Immune(playingCharacter, 1));
        Debug.Log(target.CurrentHP);
    }
}
