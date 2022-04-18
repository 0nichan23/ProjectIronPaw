using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyManager : Singleton<PartyManager>
{
    public List<Character> Heroes;
    public List<Character> Enemies;


    [SerializeField] private List<Character> pointerList;

    private List<Character> _potentialTargets;

    public Character SelectedCharacter;


    private void Start()
    {
        Enemies = EnemyWrapper.Instance.EnemyController.ControllerChracters;
        Heroes = PlayerWrapper.Instance.PlayerController.ControllerChracters;
        _potentialTargets = new List<Character>();
    }
    public IEnumerator WaitUntilHeroIsClickedPlayCard(CardSO card)
    {
        yield return new WaitUntil(() => SelectedCharacter != null);        
        PlayCard(SelectedCharacter, card);
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
        ClearCachedCharacters();
        TurnOffAllButtons(); // Turns off the button of playingCharacter
        CardEffect cardEffectRef = card.CardEffect;
        SelectedCharacter = null;
        CardUI cardui = card.CardDisplay.GetComponent<CardUI>();

        switch (cardEffectRef.TargetType)
        {
            case TargetType.Self:
                cardEffectRef.Targets.Add(playingCharacter);
                cardEffectRef.PlayEffect(playingCharacter, card);
                card.RemoveCard(playingCharacter);
                cardui.DestroyTheHeretic();
                break;

            case TargetType.SingleHero:
                // set active true for all hero allies buttons
                FillLegalTargets(playingCharacter, card, Heroes);
                TurnOnAllCachedButtons();
                StartCoroutine(WaitUntilTargetIsSelected(playingCharacter, card));
                break;

            case TargetType.RandomHero:
                System.Random rand = new System.Random();
                FillLegalTargets(playingCharacter, card, Heroes);
                Character randomHero = _potentialTargets[rand.Next(0, _potentialTargets.Count)];

                cardEffectRef.Targets.Add(randomHero);
                cardEffectRef.PlayEffect(playingCharacter, card);
                card.RemoveCard(playingCharacter);
                TurnOffAllButtons();
                cardui.DestroyTheHeretic();

                break;

            case TargetType.AllHeroes:
                foreach (Character ally in Heroes)
                {
                    cardEffectRef.Targets.Add(ally);
                }
                cardEffectRef.PlayEffect(playingCharacter, card);
                card.RemoveCard(playingCharacter);
                TurnOffAllButtons();
                cardui.DestroyTheHeretic();

                break;

            case TargetType.AllHeroesButMe:
                foreach (Character ally in Heroes)
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
                FillLegalTargets(playingCharacter, card, Enemies);
                TurnOnAllCachedButtons();
                StartCoroutine(WaitUntilTargetIsSelected(playingCharacter, card));
                break;

            case TargetType.RandomEnemy:
                System.Random rand1 = new System.Random();
                FillLegalTargets(playingCharacter, card, Enemies);
                Character randomEnemy = _potentialTargets[rand1.Next(0, _potentialTargets.Count)];

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

    private void ClearCachedCharacters()
    {
        _potentialTargets.Clear();
    }

    private void FillLegalTargets(Character playingCharacter, CardSO card, List<Character> targetList)
    {
        pointerList = targetList;

        if (card.CardType == CardType.Attack)
        {
            foreach (var character in pointerList)
            {
                foreach (var StatusEffect in character.ActiveStatusEffects)
                {
                    if(StatusEffect is Taunt)
                    {
                        _potentialTargets.Add(character);
                        break;
                    }
                }
            }
        }


        if (_potentialTargets.Count == 0)
        {
            foreach (var item in pointerList)
            {
                _potentialTargets.Add(item);
            }
        }

        pointerList = null;
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

        foreach (var hero in Heroes)
        {
            if (hero.CurrentHP > 0)
            {
                hero.Button.enabled = true;
            }
            
        }
    }

    private void TurnOnAllCachedButtons()
    {
        foreach (var character in _potentialTargets)
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

        foreach (var hero in Heroes)
        {
            hero.Button.enabled = false;
        }
    }




}
