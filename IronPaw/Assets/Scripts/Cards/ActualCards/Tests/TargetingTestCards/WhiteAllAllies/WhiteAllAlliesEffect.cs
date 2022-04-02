using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/WhiteCards/Guard/WhiteAllAlliesEffect")]
public class WhiteAllAlliesEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter)
    {
        foreach (var target in Targets)
        {
            target.GainBlock(3);
        }
    }
}
