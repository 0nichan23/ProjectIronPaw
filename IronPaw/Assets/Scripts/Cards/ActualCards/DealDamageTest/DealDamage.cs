using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/RedCards/Attacks/DealDamageAttempt")]
public class DealDamage : CardEffect
{
    protected override void PlayCardEffect()
    {
        Debug.Log("callback");
        Targets[0].TakeDmg(2);
    }

    
}
