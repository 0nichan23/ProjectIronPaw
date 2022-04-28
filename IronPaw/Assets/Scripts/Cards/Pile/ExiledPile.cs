using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExiledPile : CardPile
{
    public Action OnExileCard;

    public void ExileCard(CardScriptableObject card)
    {
        Cards.Push(card);
        OnExileCard?.Invoke();
    }
}
