using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

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
    public bool IsUsable;
    public Sprite Artwork;
    public CardType CardType;
    public GameObject CardDisplay;

    private bool CheckCardAndHeroColors(Character playingCharacter)
    {
        if (Colors[0] == Color.Colorless)
        {
            return true;
        }

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

    public void RemoveCard(Character playingCharacter)
    {
        /*  
         *  Removing the CardSO from the relevant places after it is played happens inside PartyManager.Instance.PickTargets(playingCharacter, this),
         *  because in case target selection is required, the card needs to be removed after the target was selected and not while waiting 
         *  for the player to select
         */

        // Destroy CardDisplay
        PrefabManager.Instance.DropZone.Abortion();

        // Discard this CardSO to discardpile
        playingCharacter.Hand.RemoveCard(this);
        playingCharacter.DiscardPile.Cards.Push(this);

        if (playingCharacter is Hero)
        {
            PlayerWrapper.Instance.PlayerController.CurrentEnergy -= EnergyCost;
            if (!IsSwift)
            {
                playingCharacter.CurrentAp--;
            }
        }
    }

    private void SendCardToAppropriatePile()
    {
        if (IsUsable)
        {
            /* 
             * DISCUSS: Maybe its worth for every character to reference a Hand, Deck and Exile pile, and then getting those componenets
             * will depend on whether that character is a Hero or an Enemy
            */
        }
    }

    public bool CheckCardValidity()
    {
        List<Character> cachedHeroes = new List<Character>();

        if (PlayerWrapper.Instance.PlayerController.CurrentEnergy < EnergyCost)
        {
            return false;
        }

        foreach (var hero in PlayerWrapper.Instance.PlayerController.ControllerChracters)
        {
            if (hero.CurrentHP > 0 && CheckCardAndHeroColors(hero))
            {
                if (hero.CurrentAp >= 1 || IsSwift)
                {
                    cachedHeroes.Add(hero);
                    hero.Button.enabled = true;
                }
            }
        }

        if (cachedHeroes.Count > 0)
        {
            cachedHeroes.Clear();
            return true;
        }



        cachedHeroes.Clear();
        return false;


    }


    public void GenerateCard(Character character)
    {
        /* 
         * NEVER HAVE A CARD CREATE ANOTHER COPY OF ITSELF, BROKEN AS FUCK FOR SOME REASON, REQUESTING ASSISTANCE
         * TODO: Figure why this is the case
         */

        character.Hand.AddCard(this);
        CreateCardDisplay();
    }

    public void CreateCardDisplay()
    {
        GameObject GO = Instantiate(PrefabManager.Instance.PlainCardDispaly, PlayerWrapper.Instance.PlayerController.Hand.transform);
        CardDisplay = GO;

        CardUI GOUI = GO.GetComponent<CardUI>();
        GOUI.CardSO = this;

        GOUI.InitializeDisplay();

        GameObject hand = PlayerWrapper.Instance.PlayerController.Hand.gameObject;

        GO.transform.SetParent(hand.transform);
    }




}
