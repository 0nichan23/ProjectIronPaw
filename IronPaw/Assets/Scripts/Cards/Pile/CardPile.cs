using System.Collections.Generic;
using UnityEngine;

public abstract class CardPile : MonoBehaviour
{
    Stack<CardScriptableObject> _cards = new Stack<CardScriptableObject>();

    [SerializeField]
    protected Hand _hand;


    // Will be removed/Initialized differently when deck building is a thing
    [SerializeField]
    private List<CardScriptableObject> _cardsGiven = new List<CardScriptableObject>();

    public Stack<CardScriptableObject> Cards { get => _cards; set => _cards = value; }

    private void Awake()
    {
        foreach (var card in _cardsGiven)
        {
            _cards.Push(card);
        }
    }

    public void Shuffle()
    {
        _cardsGiven.Clear();

        foreach (var card in Cards)
        {
            _cardsGiven.Add(card);
        }

        Cards.Clear();

        int n = _cardsGiven.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);

            CardScriptableObject tempCardSlot = _cardsGiven[k];
            _cardsGiven[k] = _cardsGiven[n];
            _cardsGiven[n] = tempCardSlot;
        }

        

        foreach (var card in _cardsGiven)
        {
            Cards.Push(card);
        }
    }

    public virtual void Draw()
    {
        if(Cards.Count > 0)
        {
            CardScriptableObject cardDrawn = Cards.Pop();

            _hand.AddCard(cardDrawn);

            if (!GetComponent<Enemy>())
            {
                cardDrawn.CreateCardDisplay();
            }
        }
        
    }

    // Not For Build
    public CardScriptableObject[] Search(Filter filter)
    {
        return null;
    }


}
