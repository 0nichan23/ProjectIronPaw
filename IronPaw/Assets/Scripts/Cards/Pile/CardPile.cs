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

    public Stack<CardSO> Cards { get => _cards; set => _cards = value; }

    private void Start()
    {
        foreach (var card in _cardsGiven)
        {
            Debug.Log("pushed card");
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

            CardSO tempCardSlot = _cardsGiven[k];
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
        Debug.Log("card drawn");
        CardSO cardDrawn = Cards.Pop();
        _hand.AddCard(cardDrawn);

        CreateCardDisplay(cardDrawn);

    }

    private void CreateCardDisplay(CardSO cardGiven)
    {
        GameObject GO = Instantiate(PrefabManager.Instance.PlainCardDispaly);
        cardGiven.CardDisplay = GO;

        CardUI GOUI = GO.GetComponent<CardUI>();
        GOUI.CardSO = cardGiven;
        


        GOUI.InitializeDisplay();

        GO.transform.SetParent(_hand.gameObject.transform);
    }

    // Not For Build
    public CardSO[] Search(Filter filter)
    {
        return null;
    }


}
