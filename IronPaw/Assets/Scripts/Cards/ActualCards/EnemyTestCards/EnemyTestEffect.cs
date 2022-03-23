using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/RedCards/Attacks/EnemyTestEffect")]
public class EnemyTestEffect : CardEffect
{
    protected override void PlayCardEffect()
    {
        Debug.Log("very cool enemy wow");
    }

    
}
