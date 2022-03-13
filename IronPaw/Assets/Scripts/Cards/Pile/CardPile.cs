using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardPile : MonoBehaviour
{
    Stack<CardSO> Cards;
    Hand hand;

  public abstract void Shuffle();

    public abstract void Draw(int amount);

   public abstract CardSO[] Search(Filter filter);
   

}
