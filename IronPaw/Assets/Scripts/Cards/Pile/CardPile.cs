using System.Collections.Generic;
using UnityEngine;

public abstract class CardPile : MonoBehaviour
{
    Stack<CardSO> _cards = new Stack<CardSO>();

    [SerializeField]
    private Hand _hand;


    // Will be removed/Initialized differently when deck building is a thing
    [SerializeField]
    private List<CardSO> _cardsGiven = new List<CardSO>();

    private void Start()
    {
        foreach (var card in _cardsGiven)
        {
            _cards.Push(card);
        }
    }

    public void Shuffle()
    {
        _cardsGiven.Clear();

        foreach (var card in _cards)
        {
            _cardsGiven.Add(card);
        }

        _cards.Clear();

        int n = _cardsGiven.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);

            CardSO tempCardSlot = _cardsGiven[k];
            _cardsGiven[k] = _cardsGiven[n];
            _cardsGiven[n] = tempCardSlot;
        }

        

        foreach (var card in _cardsGiven)
        {
            _cards.Push(card);
        }
    }

    public void Draw(int amount)
    {
        CardSO cardDrawn = _cards.Pop();

        CreateCardDisplay(cardDrawn);

    }

    private void CreateCardDisplay(CardSO cardGiven)
    {
        GameObject GO = Instantiate(PrefabManager.Instance.PlainCardDispaly);

        CardUI GOUI = GO.GetComponent<CardUI>();
        GOUI.CardSO = cardGiven;
        GOUI.InitializeDisplay();

        GO.transform.SetParent(_hand.gameObject.transform);
    }

    public CardSO[] Search(Filter filter)
    {
        return null;
    }


}
