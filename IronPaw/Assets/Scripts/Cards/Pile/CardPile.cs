using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardPile : MonoBehaviour
{
    Stack<CardSo> Cards;
    Hand hand;

  public abstract void Shuffle();

    public abstract void Draw(int amount);

   public abstract CardSo[] Search(Filter filter);
   

}
