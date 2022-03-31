using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/WhiteCards/Utility/WhiteSingleAllyEffect")]
public class WhiteSingleAllyEffect : CardEffect
{
    protected override void PlayCardEffect()
    {
        Character charCache = Targets[0].GetComponent<Character>();

        Debug.Log(charCache.CharacterName + " has " + charCache.CurrentHP + " health ");
        charCache.TakeDmg(4);
        Debug.Log(charCache.CharacterName + " has " + charCache.CurrentHP + " health ");
        charCache.Heal(4);
        Debug.Log(charCache.CharacterName + " has " + charCache.CurrentHP + " health ");
    }
}
