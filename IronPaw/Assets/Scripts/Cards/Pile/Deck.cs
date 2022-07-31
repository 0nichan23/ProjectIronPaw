using UnityEngine;

public class Deck : CardPile
{
    [SerializeField]
    private DiscardPile _discardPile;

    private void Start()
    {
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
}
