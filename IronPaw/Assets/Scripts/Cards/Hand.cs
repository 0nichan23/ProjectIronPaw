using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField]
    public List<Card> Cards = new List<Card>();

    [SerializeField] public DiscardPile DiscardPile;
    [SerializeField] private Controller _controller;
    bool DiscardAtTurnEnd;
    [SerializeField] private int _drawAmount;

    [SerializeField] private ScrollRect _parentScrollRect;

    private int _cardScrollThreshold = 5;
    public int DrawAmount { get => _drawAmount; set => _drawAmount = value; }

    private void Start()
    {
        _controller = DiscardPile.Controller;

    }

    public void AddCard(Card givenCard)
    {
        Cards.Add(givenCard);

        if (_controller == PlayerWrapper.Instance.PlayerController)
        {
            givenCard.SetCardDisplay();
            ToggleScrollableHand();
        }
    }

    public void GenerateCard(GameObject cardPrefab)
    {
        /* 
         * NEVER HAVE A CARD CREATE ANOTHER COPY OF ITSELF, BROKEN AS FUCK FOR SOME REASON, REQUESTING ASSISTANCE
         * TODO: Figure why this is the case
         */
        Instantiate(cardPrefab);
        AddCard(cardPrefab.GetComponent<Card>());
    }

    public void RemoveCard(Card givenCard)
    {
        Cards.Remove(givenCard);
        if (_controller == PlayerWrapper.Instance.PlayerController)
        {
            ToggleScrollableHand();
        }

    }

    private void ToggleScrollableHand()
    {
        if (Cards.Count > _cardScrollThreshold)
        {
            _parentScrollRect.enabled = true;
        }
        else
        {
            
            _parentScrollRect.horizontalNormalizedPosition = 1; //reset scroller position
            _parentScrollRect.enabled = false;
        }
    }

    public void ClearCard(Card card)
    {
        Destroy(card.CardUI);
        RemoveCard(card);
        DiscardPile.AddCardToPile(card);
    }

    public void ClearHand()
    {
        while (Cards.Count > 0)
        {
            ClearCard(Cards[0]);
        }
    }
}
