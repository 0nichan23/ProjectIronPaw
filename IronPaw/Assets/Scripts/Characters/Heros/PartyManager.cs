using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyManager : Singleton<PartyManager>
{
    public List<Character> Heros;
    public List<Character> Enemies;

    private List<Character> _charactersCache;

    public Character SelectedCharacter;


    private void Start()
    {
        Enemies = EnemyWrapper.Instance.EnemyController.ControllerChracters;
        Heros = PlayerWrapper.Instance.PlayerController.ControllerChracters;
        _charactersCache = new List<Character>();
    }
    public IEnumerator WaitUntilHeroIsClickedPlayCard(CardSO card)
    {
        yield return new WaitUntil(() => SelectedCharacter != null);
        //Debug.Log(SelectedCharacter + " was selected");
        
        PlayCard(SelectedCharacter, card);
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
        CardUI cardui = card.CardDisplay.GetComponent<CardUI>();
        cardui.DestroyTheHeretic();

    }

    public void PlayCard(Character playingCharacter, CardSO card)
    {
        _charactersCache.Clear();
        CardEffect cardEffectRef = card.CardEffect;
        SelectedCharacter = null;
        CardUI cardui = card.CardDisplay.GetComponent<CardUI>();
        switch (cardEffectRef.TargetType)
        {
            case TargetType.Self:
                cardEffectRef.Targets.Add(playingCharacter);
                cardEffectRef.PlayEffect(playingCharacter, card);
                card.RemoveCard(playingCharacter);
                TurnOffAllButtons();
                cardui.DestroyTheHeretic();
                break;

            case TargetType.SingleHero:
                // set active true for all hero allies buttons
                FillLegalTargets(playingCharacter, card);
                TurnOnAllCachedButtons();
                StartCoroutine(WaitUntilTargetIsSelected(playingCharacter, card));
                break;

            case TargetType.RandomHero:
                System.Random rand = new System.Random();
                FillLegalTargets(playingCharacter, card);
                Character randomAlly = _charactersCache[rand.Next(0, _charactersCache.Count)];

                cardEffectRef.Targets.Add(randomAlly);
                cardEffectRef.PlayEffect(playingCharacter, card);
                card.RemoveCard(playingCharacter);
                TurnOffAllButtons();
                cardui.DestroyTheHeretic();

                break;

            case TargetType.AllHeroes:
                foreach (Character ally in Heros)
                {
                    cardEffectRef.Targets.Add(ally);
                }
                cardEffectRef.PlayEffect(playingCharacter, card);
                card.RemoveCard(playingCharacter);
                TurnOffAllButtons();
                cardui.DestroyTheHeretic();

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
                cardui.DestroyTheHeretic();

                break;

            case TargetType.SingleEnemy:
                // set active true for all hero enemies buttons
                FillLegalTargets(playingCharacter, card);
                TurnOnAllCachedButtons();
                StartCoroutine(WaitUntilTargetIsSelected(playingCharacter, card));
                break;

            case TargetType.RandomEnemy:
                System.Random rand1 = new System.Random();
                FillLegalTargets(playingCharacter, card);
                Character randomEnemy = _charactersCache[rand1.Next(0, _charactersCache.Count)];

                cardEffectRef.Targets.Add(randomEnemy);

                cardEffectRef.PlayEffect(playingCharacter, card);
                card.RemoveCard(playingCharacter);
                TurnOffAllButtons();
                cardui.DestroyTheHeretic();

                break;

            case TargetType.AllEnemies:

                foreach (Character enemy in Enemies)
                {
                    cardEffectRef.Targets.Add(enemy);
                }
                cardEffectRef.PlayEffect(playingCharacter, card);
                card.RemoveCard(playingCharacter);
                TurnOffAllButtons();
                cardui.DestroyTheHeretic();

                break;
        }
    }

    private void FillLegalTargets(Character playingCharacter, CardSO card)
    {
        if(card.CardType == CardType.Attack)
        {
            List<Character> cache;
            if (playingCharacter is Hero)
            {
                cache = Enemies;
            }
            else
            {
                cache = Heros;
            }

            foreach (var character in cache)
            {
                foreach (var StatusEffect in character.ActiveStatusEffects)
                {
                    if(StatusEffect is Taunt)
                    {
                        _charactersCache.Add(character);
                        break;
                    }
                }
            }

            if (_charactersCache.Count == 0)
            {
                _charactersCache = cache;
            }

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

    private void TurnOnAllCachedButtons()
    {
        foreach (var character in _charactersCache)
        {
            if (character.CurrentHP > 0)
            {
                character.Button.enabled = true;
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
