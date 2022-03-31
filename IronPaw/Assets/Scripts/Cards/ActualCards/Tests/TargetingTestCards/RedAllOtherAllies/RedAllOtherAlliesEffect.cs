using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/RedCards/Guard/RedAllOtherAlliesEffect")]
public class RedAllOtherAlliesEffect : CardEffect
{
    protected override void PlayCardEffect()
    {
        foreach (var target in Targets)
        {
            target.GainBlock(5);
        }
    }
}
