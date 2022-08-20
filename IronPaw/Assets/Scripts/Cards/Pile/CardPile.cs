using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardPile : MonoBehaviour
{
    protected Stack<Card> _cards = new Stack<Card>();

    [SerializeField] protected Hand _hand;

    [SerializeField] protected Controller _controller;

    public Action OnDrawCard;
    public Action OnCardAdded;

    

    public Stack<Card> Cards { get => _cards; set => _cards = value; }
    public Controller Controller { get => _controller; }

    private void Awake()
    {
        DetermineController();
    }

    public void Shuffle()
    {
        List<Card> tempCards = new List<Card>();

        foreach (var card in Cards)
        {
            tempCards.Add(card);
        }

        Cards.Clear();

        int n = tempCards.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);

            Card tempCardSlot = tempCards[k];
            tempCards[k] = tempCards[n];
            tempCards[n] = tempCardSlot;
        }



        foreach (var card in tempCards)
        {
            Cards.Push(card);
        }
    }

    public virtual void Draw()
    {
        if (Cards.Count > 0)
        {
            Card cardDrawn = Cards.Pop();

            _hand.AddCard(cardDrawn);

            OnDrawCard?.Invoke();
        }

    }

    // Not For Build
    public Card[] Search(Filter filter)
    {
        return null;
    }

    public virtual void AddCardToPile(Card card)
    {
        _cards.Push(card);
        OnCardAdded?.Invoke();
    }

    

    private void DetermineController()
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
    }
}
