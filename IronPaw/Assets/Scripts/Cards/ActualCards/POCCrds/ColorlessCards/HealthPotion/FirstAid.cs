using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FirstAidEffect", menuName = "Cards/CardEffect/ColorlessCards/Utility/FirstAid")]
public class FirstAid : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.Heal(5, target);
    }
}
