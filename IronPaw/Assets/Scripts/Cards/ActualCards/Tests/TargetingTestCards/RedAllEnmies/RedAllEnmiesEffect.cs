using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/RedCards/Attacks/RedAllEnmiesEffect")]
public class RedAllEnmiesEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter)
    {
        foreach (var target in Targets)
        {
            
            target.TakeDmg(new Damage(3, playingCharacter));
        }
    }
}
