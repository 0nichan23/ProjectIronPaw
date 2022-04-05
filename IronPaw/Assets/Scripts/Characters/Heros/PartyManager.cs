using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyManager : Singleton<PartyManager>
{
    public List<Character> Heros;
    public List<Character> Enemies;

    public Character SelectedCharacter;


    private void Start()
    {
        Enemies = EnemyWrapper.Instance.EnemyController.Enemies;
        Heros = PlayerWrapper.Instance.PlayerController.ControllerChracters;
    }
    public IEnumerator WaitUntilHeroIsClickedPlayCard(CardSO card/*, Event func*/)
    {
        TurnOnAllHeroButtons(card);
        yield return new WaitUntil(() => SelectedCharacter != null);
        Debug.Log(SelectedCharacter + " was selected");
        card.PlayCard(SelectedCharacter);
        SelectedCharacter = null;
    }

    public IEnumerator WaitUntilTargetIsSelected (Character playingCharacter, CardSO card)
    {
        yield return new WaitUntil(() => SelectedCharacter != null);
        card.CardEffect.Targets.Add(SelectedCharacter);
        card.CardEffect.PlayEffect(playingCharacter, card);
        card.RemoveCard(playingCharacter);
        SelectedCharacter = null;
        TurnOffAllButtons();
    }

    public void PickTargets(Character playingCharacter, CardSO card)
    {
        CardEffect cardEffectRef = card.CardEffect;
        SelectedCharacter = null;
        switch (cardEffectRef.TargetType)
        {
            case TargetType.Self:
                cardEffectRef.Targets.Add(playingCharacter);
                cardEffectRef.PlayEffect(playingCharacter, card);
                card.RemoveCard(playingCharacter);
                TurnOffAllButtons();
                break;

            case TargetType.SingleHero:
                // set active true for all hero allies buttons
                TurnOnAllHeroButtons();
                StartCoroutine(WaitUntilTargetIsSelected(playingCharacter, card));
                break;

            case TargetType.RandomHero:
                System.Random rand = new System.Random();
                Character randomAlly = Heros[rand.Next(0, Heros.Count)];

                cardEffectRef.Targets.Add(randomAlly);
                cardEffectRef.PlayEffect(playingCharacter, card);
                card.RemoveCard(playingCharacter);
                TurnOffAllButtons();
                break;

            case TargetType.AllHeroes:
                foreach (Character ally in Heros)
                {
                    cardEffectRef.Targets.Add(ally);
                }
                cardEffectRef.PlayEffect(playingCharacter, card);
                card.RemoveCard(playingCharacter);
                TurnOffAllButtons();
                break;

            case TargetType.AllHeroesButMe:
                foreach (Character ally in Heros)
                {
                    if(ally != playingCharacter)
                    {
                        cardEffectRef.Targets.Add(ally);
                    }                 
                }
                cardEffectRef.PlayEffect(playingCharacter, card);
                card.RemoveCard(playingCharacter);
                TurnOffAllButtons();
                break;

            case TargetType.SingleEnemy:
                // set active true for all hero enemies buttons
                TurnOnAllEnemyButtons();
                StartCoroutine(WaitUntilTargetIsSelected(playingCharacter, card));
                break;

            case TargetType.RandomEnemy:
                System.Random rand1 = new System.Random();
                Character randomEnemy = Enemies[rand1.Next(0, Enemies.Count)];

                cardEffectRef.Targets.Add(randomEnemy);

                cardEffectRef.PlayEffect(playingCharacter, card);
                card.RemoveCard(playingCharacter);
                TurnOffAllButtons();
                break;

            case TargetType.AllEnemies:

                foreach (Character enemy in Enemies)
                {
                    cardEffectRef.Targets.Add(enemy);
                }
                cardEffectRef.PlayEffect(playingCharacter, card);
                card.RemoveCard(playingCharacter);
                TurnOffAllButtons();
                break;
        }

        

    }

    private void TurnOnAllEnemyButtons()
    {
        foreach (var enemy in Enemies)
        {
            if (enemy.CurrentHP > 0)
            {
                enemy.Button.enabled = true;
            }
           
        }
    }

    private void TurnOnAllHeroButtons()
    {
        // TODO: Filter heros by color, ifAlive, and so on

        foreach (var hero in Heros)
        {
            if (hero.CurrentHP > 0)
            {
                hero.Button.enabled = true;
            }
            
        }
    }
    private void TurnOnAllHeroButtons(CardSO card)
    {
       
        foreach (var hero in Heros)
        {
            if (hero.CurrentHP > 0)
            {
                foreach (Color heroColor in hero.Colors)
                {
                    foreach (Color cardColor in card.Colors)
                    {
                        if (heroColor == cardColor)
                        {
                            hero.Button.enabled = true;
                            
                        }
                    }
                    
                }
                
            }

        }
    }

    private void TurnOffAllButtons()
    {
        foreach (var enemy in Enemies)
        {
            enemy.Button.enabled = false;
        }

        foreach (var hero in Heros)
        {
            hero.Button.enabled = false;
        }
    }




}
