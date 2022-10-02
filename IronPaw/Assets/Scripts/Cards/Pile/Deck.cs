using System.Collections.Generic;
using UnityEngine;

public class Deck : CardPile
{
    [SerializeField]
    private DiscardPile _discardPile;

    [SerializeField] private List<Card> _cardsRef; // for debugging through inspector

    private bool _isReady;

    // Will be removed/Initialized differently when deck building is a thing
    [SerializeField] private List<GameObject> _cardsGiven = new List<GameObject>();
    [SerializeField] private List<DeckSO> _decksGiven = new List<DeckSO>();

    public bool IsReady { get => _isReady; set => _isReady = value; }

    private void Start()
    {
        InitDeck();
        Shuffle();
    }

    

    public override void Draw()
    {
        if (Cards.Count == 0 && _discardPile.Cards.Count > 0)
        {
            int numberOfCardsToShuffle = _discardPile.Cards.Count;

            for (int i = 0; i < numberOfCardsToShuffle; i++)
            {
                Cards.Push(_discardPile.Cards.Pop());
            }

            Shuffle();  
        }

        base.Draw();
    }

    public void DrawOnEditor()
    {
#if UNITY_EDITOR

        Draw();
#endif
    }

    private void InitDeck()
    {
        foreach (GameObject cardGO in _cardsGiven)
        {
            InstantiateNewCardAndAddToDeck(cardGO);
        }

        foreach (DeckSO deck in _decksGiven)
        {
            foreach (GameObject cardGO in deck.Cards)
            {
                InstantiateNewCardAndAddToDeck(cardGO);
            }
        }

        IsReady = true;
    }

    private void InstantiateNewCardAndAddToDeck(GameObject cardGO)
    {
        GameObject newCard = Instantiate(cardGO, this.transform);
        newCard.SetActive(false);
        var newCardComp = newCard.GetComponent<Card>();
        _cards.Push(newCardComp);
        _cardsRef.Add(newCardComp); // for debugging through inspector
    }
}
