using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/GreenCards/Attacks/GreenRandomEnemyEffect")]
public class GreenRandomEnemyEffect : CardEffect
{
    protected override void PlayCardEffect()
    {
        Character charCache = Targets[0].GetComponent<Character>();

        Debug.Log(charCache.CurrentHP);
        charCache.TakeDmg(6);
        Debug.Log(charCache.CurrentHP);
    }
}
