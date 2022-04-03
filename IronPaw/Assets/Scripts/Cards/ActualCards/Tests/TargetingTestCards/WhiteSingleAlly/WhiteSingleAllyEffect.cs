using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/WhiteCards/Utility/WhiteSingleAllyEffect")]
public class WhiteSingleAllyEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        Debug.Log(target.CharacterName + " has " + target.CurrentHP + " health ");
        target.TakeDmg(new Damage(4, playingCharacter));
        Debug.Log(target.CharacterName + " has " + target.CurrentHP + " health ");
        target.Heal(4);
        Debug.Log(target.CharacterName + " has " + target.CurrentHP + " health ");
    }
}
