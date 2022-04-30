using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DvineProtectionEffect", menuName = "Cards/CardEffect/WhiteCards/Utility/DvineProtectionEffect")]

public class DvineProtectionEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.GainBlock(6);
        
    }
}
