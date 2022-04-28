using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EldritchBlast", menuName = "Cards/CardEffect/ColorlessCards/Attack/EldritchBlastEffect")]

public class EldritchBlastEffect : CardEffect
{
    protected override void PlayCardEffect(Character playingCharacter, Character target)
    {
        target.TakeDmg(new Damage (10, playingCharacter, true));
    }
}
