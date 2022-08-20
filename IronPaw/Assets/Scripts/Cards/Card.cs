using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Card : MonoBehaviour
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
    public UtilityBuffType BuffType;



    public bool CheckCardAndHeroColors(Character playingCharacter)
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


    public void SpendResources(Character playingCharacter)
    {
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

    public void SendCardToAppropriatePile(Character playingCharacter)
    {
        if (IsUsable)
        {
            playingCharacter.ExiledPile.AddCardToPile(this);
        }
        else // Discard this CardSO to discardpile
        {
            playingCharacter.DiscardPile.AddCardToPile(this);
        }
    }

    public bool CheckCardValidity()
    {
        List<Character> cachedHeroes = new List<Character>();

        CombatManager.Instance.TurnOffAllButtons();

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
                    hero.ToggleCharacterSelectability(true, hero.Colors[0]);
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

    public void SetCardDisplay()
    {
        transform.SetParent(PlayerWrapper.Instance.PlayerController.Hand.gameObject.transform);
    }

    public void ClearTargetsFromCardEffect()
    {
        // The Shadow Realm Bug

        if (CardEffect != null)
        {
            CardEffect.Targets.Clear();
        }
    }




}
