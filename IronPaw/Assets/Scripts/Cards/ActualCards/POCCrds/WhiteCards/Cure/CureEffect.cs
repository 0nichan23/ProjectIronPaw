using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CureEffect", menuName = "Cards/CardEffect/WhiteCards/Guard/CureEffect")]

public class CureEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.Heal(3, playingCharacter);
        List<StatusEffect> debuffs = new List<StatusEffect>();
        foreach (var statusEffect in target.ActiveStatusEffects)
        {
            if (statusEffect is Debuff)
            {
                debuffs.Add(statusEffect);
                target.GainBlock(3);
            }
        }
        foreach ( var item in debuffs)
        {
            item.RemoveStatusEffectFromHost();
        }
       
    }
}
