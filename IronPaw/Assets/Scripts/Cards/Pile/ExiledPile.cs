using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExiledPile : CardPile
{
    public override void AddCardToPile(CardScriptableObject card)
    {
        base.AddCardToPile(card);
        //AudioManager.Instance.Play(AudioManager.Instance.SfxClips[5]);
    }

    
}
