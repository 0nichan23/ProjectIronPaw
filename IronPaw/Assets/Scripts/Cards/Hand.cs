using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField]
    public List<CardScriptableObject> Cards = new List<CardScriptableObject>();

    [SerializeField] public DiscardPile DiscardPile;
    [SerializeField] private Controller _controller;
    bool DiscardAtTurnEnd;
    [SerializeField] private int _drawAmount;

    public int DrawAmount { get => _drawAmount; set => _drawAmount = value; }

    private void Start()
    {
        _controller = DiscardPile.Controller;
    }

    public void AddCard(CardScriptableObject givenCard)
    {
        Cards.Add(givenCard);

        if (_controller == PlayerWrapper.Instance.PlayerController)
        {
            givenCard.CreateCardDisplay();
            //UpdateHandFanShape();
        }

        
    }

    private void UpdateHandFan()
    {
        CardUI[] children = GetComponentsInChildren<CardUI>();

        foreach (var child in children)
        {
            child.Container = child.OriginalTransform;
        }

        int degreeToRotate = 80 / Cards.Count;

        int numberOfCardsOnEachSide = Cards.Count / 2;

        for (int i = 0; i < numberOfCardsOnEachSide; i++)
        {
            int multiplier = numberOfCardsOnEachSide - i;
            children[i].Container.localEulerAngles =  new Vector3(0, 0, multiplier * degreeToRotate);
            children[i].Container.localPosition -= new Vector3(0, (multiplier) * 3, 0);
        }

        if (numberOfCardsOnEachSide != 0)
        {
            //int firstCardIndexOfOtherSide = numberOfCardsOnEachSide;
            //if (Cards.Count % 2 != 0)
            //{
            //    firstCardIndexOfOtherSide++;
            //}


                for (int i = Cards.Count-1; i > numberOfCardsOnEachSide; i--)
                {
                    int multiplier = numberOfCardsOnEachSide - i;   // multiplier will be negative here
                    children[i].Container.localEulerAngles = new Vector3(0, 0, multiplier * degreeToRotate);
                    children[i].Container.localPosition -= new Vector3(0, (-multiplier) * 3, 0);
                }        
        }

        //foreach (var child in children)
        //{
        //    child.Container.localRotation 
        //}
    }

    private void UpdateHandFanShape()
    {
        float totalTwist = 60f;
        int numberOfCardsInHand = Cards.Count;
        float twistPerCard = totalTwist / (numberOfCardsInHand-1);

        float startTwist = 1f * (totalTwist / 2f);

        
        float totalRaise = 70f;
        float raisePerCard = totalRaise / numberOfCardsInHand;
        Debug.Log(raisePerCard);

        CardUI[] _cardUIsInHand = GetComponentsInChildren<CardUI>();

        float nextRaise = 0;

        for (int i = 0; i < _cardUIsInHand.Length; i++)
        {
            _cardUIsInHand[i].Container.localEulerAngles = Vector3.zero;
            _cardUIsInHand[i].Container.localPosition = Vector3.zero;
        }

        for (int i = 0; i < _cardUIsInHand.Length; i++)
        {
            float twistForThisCard = startTwist - (i * twistPerCard);
            _cardUIsInHand[i].Container.localEulerAngles = new Vector3(0, 0, twistForThisCard);

            float raiseForThisCard = i * raisePerCard;
            _cardUIsInHand[i].Container.localPosition = new Vector3(_cardUIsInHand[i].Container.localPosition.x, totalRaise - nextRaise, _cardUIsInHand[i].Container.localPosition.z);
            _cardUIsInHand[_cardUIsInHand.Length-1-i].Container.localPosition = new Vector3(_cardUIsInHand[i].Container.localPosition.x, totalRaise - nextRaise, _cardUIsInHand[i].Container.localPosition.z);
            nextRaise += raisePerCard;
        }
    }

    public void RemoveCard(CardScriptableObject givenCard)
    {
        Cards.Remove(givenCard);
    }

    public void ClearCard(CardScriptableObject card)
    {
        Destroy(card.CardDisplay);
        RemoveCard(card);
        DiscardPile.AddCardToPile(card);
    }

    public void ClearHand()
    {
        while(Cards.Count > 0)
        {
            ClearCard(Cards[0]);
        }
    }
}
