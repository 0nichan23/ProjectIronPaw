using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardScriptableObject")]
public class CardScriptableObject : ScriptableObject
{
    public string CardName;
    public string Description;
    public ColorIdentity[] Colors;
    public Rarity Rarity;
    public int EnergyCost;
    [SerializeField]
    public CardEffect CardEffect;
    public bool IsSwift;
    public bool IsUsable;
    public Sprite Artwork;
    public CardType CardType;
    public GameObject CardDisplay;
    public List<KeyWords> Keywords = new List<KeyWords>();

    private bool CheckCardAndHeroColors(Character playingCharacter)
    {
        if (Colors[0] == ColorIdentity.Colorless)
        {
            return true;
        }

        foreach (ColorIdentity heroColor in playingCharacter.Colors)
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

        // Discard this CardSO to discardpile

        SendCardToAppropriatePile(playingCharacter);

        if (playingCharacter is Hero)
        {
            PlayerWrapper.Instance.PlayerController.CurrentEnergy -= EnergyCost;
            PlayerWrapper.Instance.PlayerController.UpdatePlayerUI();

            if (!IsSwift)
            {
                playingCharacter.CurrentAp--;
                playingCharacter.UpdateUI();
            }
        }
    }

    private void SendCardToAppropriatePile(Character playingCharacter)
    {
        playingCharacter.Hand.RemoveCard(this);

        if (IsUsable)
        {
            playingCharacter.ExiledPile.AddCardToPile(this);
        }
        else
        {
            playingCharacter.DiscardPile.AddCardToPile(this);
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
                    hero.Button.gameObject.SetActive(true);
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
    }

    public void CreateCardDisplay()
    {
        GameObject GO = Instantiate(PrefabManager.Instance.PlainCardDispaly, PlayerWrapper.Instance.PlayerController.Hand.transform);
        CardDisplay = GO;

        GO.transform.SetParent(PlayerWrapper.Instance.PlayerController.Hand.gameObject.transform);

        CardUI GOUI = GO.GetComponent<CardUI>();
        GOUI.CardSO = this;

        GOUI.InitializeDisplay();
    }

    public void ClearTargetsFromCardEffect()
    {
        // The Shadow Realm Bug

        if(CardEffect != null)
        {
            CardEffect.Targets.Clear();
        }        
    }




}
