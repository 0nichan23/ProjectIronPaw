using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : CardPile
{
    [SerializeField]
    private DiscardPile _discardPile;

    public override void Draw()
    {
        if(Cards.Count == 0)
        {
            int numberOfCardsToShuffle = _discardPile.Cards.Count;

            for (int i = 0; i < numberOfCardsToShuffle; i++)
            {
                Cards.Push(_discardPile.Cards.Pop());
            }

            Shuffle();  
        }
         
        base.Draw();
    }
}
