using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardPile : MonoBehaviour
{
    Stack<CardScriptableObject> _cards = new Stack<CardScriptableObject>();

    [SerializeField] protected Hand _hand;

    [SerializeField] protected Controller _controller;

    public Action OnDrawCard;
    public Action OnCardAdded;

    // Will be removed/Initialized differently when deck building is a thing
    [SerializeField]
    private List<CardScriptableObject> _cardsGiven = new List<CardScriptableObject>();

    public Stack<CardScriptableObject> Cards { get => _cards; set => _cards = value; }

    private void Awake()
    {
        if (!GetComponent<Enemy>())
        {
            _controller = PlayerWrapper.Instance.PlayerController;
            OnDrawCard += ((PlayerController)_controller).UpdatePlayerUI;
            OnCardAdded += ((PlayerController)_controller).UpdatePlayerUI;
        }
        else
        {
            _controller = EnemyWrapper.Instance.EnemyController;
        }

        InitDeck();
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
            int k = UnityEngine.Random.Range(0, n + 1);

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
        if (Cards.Count > 0)
        {
            CardScriptableObject cardDrawn = Cards.Pop();

            _hand.AddCard(cardDrawn);

            if (_controller == PlayerWrapper.Instance.PlayerController)
            {
                cardDrawn.CreateCardDisplay();
            }

            OnDrawCard?.Invoke();
        }

    }

    // Not For Build
    public CardScriptableObject[] Search(Filter filter)
    {
        return null;
    }

    public virtual void AddCardToPile(CardScriptableObject card)
    {
        _cards.Push(card);
        OnCardAdded?.Invoke();
    }

    private void InitDeck()
    {
        foreach (CardScriptableObject card in _cardsGiven)
        {
            _cards.Push(card);
        }
    }
}
