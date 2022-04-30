using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Earthquake", menuName = "Cards/CardEffect/ColorlessCards/Attack/EarthquakeEffect")]

public class EarthquakeEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage(2, playingCharacter, true));
        target.AddStatusEffect(new Frail(target, 2));
    }
}
