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
            Debug.Log("Walla no Energy");
            return false;
        }

        foreach (var hero in PlayerWrapper.Instance.PlayerController.ControllerChracters)
        {
            if (hero.CurrentHP > 0 && CheckCardAndHeroColors(hero))
            {
                if(hero.CurrentAp >= 1 || IsSwift)
                {
                    cachedHeroes.Add(hero);
                    hero.Button.enabled = true;
                }
            }
        }

        Debug.Log("cachedHeroes.Count: " + cachedHeroes.Count);

        if (cachedHeroes.Count > 0)
        {
            cachedHeroes.Clear();
            return true;
        }

       

        cachedHeroes.Clear();
        return false;

       
    }




}
