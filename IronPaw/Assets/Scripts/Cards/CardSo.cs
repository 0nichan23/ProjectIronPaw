using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardSO")]
public class CardSO : ScriptableObject
{
    public string CardName;
    public string Description;
    public Color[] Colors;
    public Rarity Rarity;
    public int EnergyCost;
    [SerializeField]
    public CardEffect CardEffect;
    public bool IsSwift;
    public Sprite Artwork;
    public CardType CardType;
    public GameObject CardDisplay;

    public void PlayCard(Character playingCharacter)
    {
        if (CheckCardAndHeroColors(playingCharacter))
        {
            if (PlayerWrapper.Instance.PlayerController.CurrentEnergy >= EnergyCost || playingCharacter is Enemy)
            {
                if (playingCharacter.CurrentAp >= 1 || IsSwift)
                {
                    PartyManager.Instance.PickTargets(playingCharacter, this);
                }
            }
        }
    }


    public void RemoveCard(Character playingCharacter)
    {

        /*  
         *  Removing the CardSO from the relevant places after it is played happens inside PartyManager.Instance.PickTargets(playingCharacter, this),
         *  because in case target selection is required, the card needs to be removed after the target was selected and not while waiting 
         *  for the player to select
         */

        // Destroy CardDisplay
        Destroy(CardDisplay);

        // Discard this CardSO to discardpile
        if (playingCharacter is Hero)
        {
            PlayerWrapper.Instance.PlayerController.Hand.RemoveCard(this);
            PlayerWrapper.Instance.PlayerController.DiscardPile.Cards.Push(this);
            PlayerWrapper.Instance.PlayerController.CurrentEnergy -= EnergyCost;
            if (!IsSwift)
            {
                playingCharacter.CurrentAp--;
            }
        }
        else if (playingCharacter is Enemy)
        {
            Enemy _playingEnemy = playingCharacter.GetComponent<Enemy>();

            _playingEnemy.Hand.RemoveCard(this);
            _playingEnemy.DiscardPile.Cards.Push(this);
        }


    }

    private bool CheckCardAndHeroColors(Character playingCharacter)
    {
        foreach (Color heroColor in playingCharacter.Colors)
        {
            foreach (var cardColor in Colors)
            {
                if (heroColor == cardColor)
                {
                    return true;
                }
            }
        }

        return false;
    }


}
