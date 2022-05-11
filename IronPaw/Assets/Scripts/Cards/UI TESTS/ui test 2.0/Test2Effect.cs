using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/Colorless/Utility/test2effect")]
public class Test2Effect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(3, target));
        target.AddStatusEffect(new Bleed(target, 3));
        target.AddStatusEffect(new Taunt(target, 3));

        playingCharacter.Heal(1, playingCharacter);
        Debug.Log("playing: " + playingCharacter.CharacterName);
        Debug.Log(target.CharacterName);
    }
}
