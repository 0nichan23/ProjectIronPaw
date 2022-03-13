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

    }

    public void Draw(int amount)
    {
        CardSO cardDrawn = _cards.Pop();

        GameObject GO = Instantiate(PrefabManager.Instance.PlainCardDispaly);

        CardUI GOUI = GO.GetComponent<CardUI>();
        GOUI.CardSO = cardDrawn;
        GOUI.InitializeDisplay();

        GO.transform.SetParent(_hand.gameObject.transform);
        
        // Instantiate Card UI

    }

    public CardSO[] Search(Filter filter)
    {
        return null;
    }


}
