using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/RedCards/Attacks/RedSingleEnemyEffect")]
public class RedSingleEnemyEffect : CardEffect
{
    protected override void PlayCardEffect()
    {
        Character charCache = Targets[0].GetComponent<Character>();

        Debug.Log(charCache.CurrentHP);
        charCache.TakeDmg(5);
        Debug.Log(charCache.CurrentHP);
    }
}
