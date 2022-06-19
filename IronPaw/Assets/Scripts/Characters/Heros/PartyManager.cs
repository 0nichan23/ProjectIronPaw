using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : Singleton<PartyManager>
{
    public List<Character> Heroes;
    public List<Character> Enemies;

    public bool RerolledTargetsForTaunt = false;

    [SerializeField] private List<Character> _pointerList;

    private List<Character> _potentialTargets;

    public Character SelectedCharacter;
    public CardUI SelectedCardUI;

    private void Start()
    {
        Enemies = new List<Character> ( EnemyWrapper.Instance.EnemyController.ControllerChracters );
        Heroes = new List<Character> ( PlayerWrapper.Instance.PlayerController.ControllerChracters );
        _potentialTargets = new List<Character>();
    }

    #region Enemy Functions
    public void EnemyAcquireTargets(Enemy playingEnemy, CardScriptableObject card)
    {
        playingEnemy.Targets.Clear();
        ClearCachedCharacters();

        switch (card.CardEffect.TargetType)
        {
            case TargetType.Self:
                playingEnemy.Targets.Add(playingEnemy);
                break;

            case TargetType.RandomHero:
                if (Heroes.Count == 0)
                {
                    return;
                }
                System.Random rand = new System.Random();
                FillLegalTargets(playingEnemy, card, Heroes);
                Character randomHero = _potentialTargets[rand.Next(0, _potentialTargets.Count)];
                playingEnemy.Targets.Add(randomHero);
                break;

            case TargetType.AllHeroes:
                foreach (Character hero in Heroes)
                {
                    playingEnemy.Targets.Add(hero);
                }
                break;

            case TargetType.RandomEnemy:
                System.Random rand1 = new System.Random();
                FillLegalTargets(playingEnemy, card, Enemies);
                Character randomEnemy = _potentialTargets[rand1.Next(0, _potentialTargets.Count)];
                playingEnemy.Targets.Add(randomEnemy);

                break;

            case TargetType.AllEnemies:
                foreach (Character enemy in Enemies)
                {
                    playingEnemy.Targets.Add(enemy);
                }
                break;

            case TargetType.AllCharacters:
                foreach (Character hero in Heroes)
                {
                    playingEnemy.Targets.Add(hero);
                }
                foreach (Character enemy in Enemies)
                {
                    playingEnemy.Targets.Add(enemy);
                }
                break;

            case TargetType.AllCharactersButMe:
                foreach (Character hero in Heroes)
                {
                    if (hero == playingEnemy)
                    {
                        continue;
                    }
                    playingEnemy.Targets.Add(hero);
                }
                foreach (Character enemy in Enemies)
                {
                    if (enemy == playingEnemy)
                    {
                        continue;
                    }
                    playingEnemy.Targets.Add(enemy);
                }
                break;

            default:
                throw new NullReferenceException("Invalid TargetType for!" + card.CardName);
        }


    }

    public void EnemiesRerollTargetsForNewTaunts()
    {
        if (RerolledTargetsForTaunt)
        {
            return;
        }

        foreach (Enemy enemy in Enemies)
        {
            if (enemy.Hand.Cards.Count != 0)
            {
                EnemyAcquireTargets(enemy, enemy.Hand.Cards[0]);
                enemy.UpdateUI();
            }
        }

        RerolledTargetsForTaunt = true;
    }

    public void EnemyPlayCard(Enemy playingEnemy, CardScriptableObject card)
    {
        foreach (var target in playingEnemy.Targets)
        {
            if (target.IsAlive)
            {
                card.CardEffect.Targets.Add(target);
            }
           

        }
        playingEnemy.Targets.Clear();

        StartCoroutine(PlayCardAnimationSync(playingEnemy, card, card.CardEffect, null));
    }

    public void ResetRerollForTaunt()
    {
        RerolledTargetsForTaunt = false;
    }
    #endregion

    #region Player Functions
    public void PlayCard(Character playingCharacter, CardScriptableObject card)
    {
        
        ClearCachedCharacters();
        TurnOffAllButtons();
        CardEffect cardEffectRef = card.CardEffect;
        SelectedCharacter = null;
        CardUI cardUI = null;
        if (playingCharacter is Hero)
        {
            cardUI = card.CardDisplay.GetComponent<CardUI>();
        }

        switch (cardEffectRef.TargetType)
        {
            case TargetType.Self:
                cardEffectRef.Targets.Add(playingCharacter);
                StartCoroutine(PlayCardAnimationSync(playingCharacter, card, card.CardEffect, null));

                break;

            case TargetType.SingleHero:
                // set active true for all hero allies buttons
                FillLegalTargets(playingCharacter, card, Heroes);
                TurnOnAllCachedButtons(card.Colors[0]);
                StartCoroutine(WaitUntilTargetIsSelected(playingCharacter, card, cardEffectRef, cardUI));
                break;

            case TargetType.RandomHero:
                System.Random rand = new System.Random();
                FillLegalTargets(playingCharacter, card, Heroes);
                Character randomHero = _potentialTargets[rand.Next(0, _potentialTargets.Count)];
                cardEffectRef.Targets.Add(randomHero);
                StartCoroutine(PlayCardAnimationSync(playingCharacter, card, card.CardEffect, null));

                break;

            case TargetType.AllHeroes:
                foreach (Character ally in Heroes)
                {
                    cardEffectRef.Targets.Add(ally);
                }
                StartCoroutine(PlayCardAnimationSync(playingCharacter, card, card.CardEffect, null));

                break;

            case TargetType.AllHeroesButMe:
                foreach (Character ally in Heroes)
                {
                    if (ally != playingCharacter)
                    {
                        cardEffectRef.Targets.Add(ally);
                    }
                }
                StartCoroutine(PlayCardAnimationSync(playingCharacter, card, card.CardEffect, null));

                break;

            case TargetType.SingleEnemy:
                // set active true for all hero enemies buttons
                FillLegalTargets(playingCharacter, card, Enemies);
                TurnOnAllCachedButtons(card.Colors[0]);
                StartCoroutine(WaitUntilTargetIsSelected(playingCharacter, card, cardEffectRef, cardUI));
                break;

            case TargetType.RandomEnemy:
                System.Random rand1 = new System.Random();
                FillLegalTargets(playingCharacter, card, Enemies);
                Character randomEnemy = _potentialTargets[rand1.Next(0, _potentialTargets.Count)];
                cardEffectRef.Targets.Add(randomEnemy);
                StartCoroutine(PlayCardAnimationSync(playingCharacter, card, card.CardEffect, null));

                break;

            case TargetType.AllEnemies:
                foreach (Character enemy in Enemies)
                {
                    cardEffectRef.Targets.Add(enemy);
                }
                StartCoroutine(PlayCardAnimationSync(playingCharacter, card, card.CardEffect, null));
                break;

            case TargetType.AllCharacters:
                foreach (Character hero in Heroes)
                {
                    cardEffectRef.Targets.Add(hero);
                }
                foreach (Character enemy in Enemies)
                {
                    cardEffectRef.Targets.Add(enemy);
                }
                StartCoroutine(PlayCardAnimationSync(playingCharacter, card, card.CardEffect, null));
                break;

            case TargetType.AllCharactersButMe:
                foreach (Character hero in Heroes)
                {
                    if (hero == playingCharacter)
                    {
                        continue;
                    }
                    cardEffectRef.Targets.Add(hero);
                }
                foreach (Character enemy in Enemies)
                {
                    if (enemy == playingCharacter)
                    {
                        continue;
                    }
                    cardEffectRef.Targets.Add(enemy);
                }
                StartCoroutine(PlayCardAnimationSync(playingCharacter, card, card.CardEffect, null));
                break;
        }
    }

    public void SelectHeroToUltimate()
    {
        StartCoroutine(WaitUntilHeroIsClickedUltimate());
    }

    private IEnumerator WaitUntilHeroIsClickedUltimate()
    {
        if(PlayerWrapper.Instance.PlayerController.UltimateReady)
        {
            UIManager.Instance.ToggleSelectionCanvas(true, "Select a Hero");
            TurnOnAllHeroButtons();

            yield return new WaitUntil(() => SelectedCharacter != null);
            TurnOffAllButtons();
            UIManager.Instance.ToggleSelectionCanvas(false, null);
            ((Hero)SelectedCharacter).PerformUltimate();
            SelectedCharacter = null;
        }        
    }

    public IEnumerator WaitUntilHeroIsClickedPlayCard(CardScriptableObject card)
    {
        UIManager.Instance.ToggleSelectionCanvas(true, "Select a Hero");
        yield return new WaitUntil(() => SelectedCharacter != null);
        TurnOffAllButtons();
        PlayCard(SelectedCharacter, card);
    }

    public IEnumerator WaitUntilTargetIsSelected(Character playingCharacter, CardScriptableObject card, CardEffect cardEffectRef, CardUI cardUI)
    {
        UIManager.Instance.SelectionCanvas.Title.text = "Select a target";
        yield return new WaitUntil(() => SelectedCharacter != null);

        cardEffectRef.Targets.Add(SelectedCharacter);
        StartCoroutine(PlayCardAnimationSync(playingCharacter, card, card.CardEffect, null));
        SelectedCharacter = null;
    }

    public void CancelCard()
    {
        StopCoroutine("WaitUntilHeroIsClickedPlayCard");
        StopCoroutine("WaitUntilHeroIsClickedUltimate");
        StopCoroutine("WaitUntilTargetIsSelected");
        SelectedCharacter = null;
        _pointerList = null;
        TurnOffAllButtons();
        ClearCachedCharacters();
        if(SelectedCardUI)
        {
            SelectedCardUI.DeselectCard();
        }        
        UIManager.Instance.ToggleSelectionCanvas(false, null);
    }
    #endregion

    #region Universal Functions

    private void FillLegalTargets(Character playingCharacter, CardScriptableObject card, List<Character> targetList)
    {
        _pointerList = targetList;
        ClearCachedCharacters();
        if (card.CardType == CardType.Attack)
        {
            foreach (var character in _pointerList)
            {
                if (character.IsAlive)
                {
                    foreach (var statusEffect in character.ActiveStatusEffects)
                    {
                        if (statusEffect is Taunt)
                        {
                            _potentialTargets.Add(character);
                            break;
                        }
                    }
                }
            }
        }

        if (_potentialTargets.Count == 0)
        {
            foreach (var character in _pointerList)
            {
                if (character.IsAlive)
                {
                    _potentialTargets.Add(character);
                }
            }
        }

        _pointerList = null;
    }
    
    private IEnumerator PlayCardAnimationSync(Character playingCharacter, CardScriptableObject card, CardEffect cardEffectRef, CardUI cardUI)
    {
        /* 1. */ CardCleanup(playingCharacter, card, cardEffectRef, cardUI);
        /* 2. */ //CardUICleanup(playingCharacter, card, cardEffectRef, cardUI);
        if (card.CardType == CardType.Attack)
        {
            playingCharacter.PlayAnimation(card.CardType);
            yield return new WaitUntil(() => playingCharacter.ReachedAnimationSyncFrame);
        }
        playingCharacter.ReachedAnimationSyncFrame = false;
        cardEffectRef.PlayEffect(playingCharacter, card);
        /* 2. */ //CardSOCleanup(playingCharacter, card);
    }

    private void CardCleanup(Character playingCharacter, CardScriptableObject card, CardEffect cardEffectRef, CardUI cardUI)
    {
        card.RemoveCard(playingCharacter);
        if (cardUI != null)
        {
            cardUI.DestroyTheHeretic();
        }
        ReInitHand();
        TurnOffAllButtons();
        UIManager.Instance.ToggleSelectionCanvas(false, null);
    }

    private void CardUICleanup(Character playingCharacter, CardScriptableObject card, CardEffect cardEffectRef, CardUI cardUI)
    {
        if (cardUI != null)
        {
            cardUI.DestroyTheHeretic();       
        }
        TurnOffAllButtons();
        UIManager.Instance.ToggleSelectionCanvas(false, null);
    }

    private void CardSOCleanup(Character playingCharacter, CardScriptableObject card)
    {
        card.RemoveCard(playingCharacter);
        ReInitHand();
    }

    private void ReInitHand()
    {
        GameObject Hand = PlayerWrapper.Instance.PlayerController.Hand.gameObject;
        for (int i = 0; i < Hand.transform.childCount; i++)
        {           
            Hand.transform.GetChild(i).GetComponent<CardUI>().DestroyTheHeretic();
        }

        foreach (var card in PlayerWrapper.Instance.PlayerController.Hand.Cards)
        {
            card.CreateCardDisplay();
        }
    }    

    private void ClearCachedCharacters()
    {
        _potentialTargets.Clear();
    }

    private void TurnOnAllEnemyButtons()
    {
        foreach (var enemy in Enemies)
        {
            if (enemy.CurrentHP > 0)
            {
                enemy.Button.gameObject.SetActive(true);
            }

        }
    }

    private void TurnOnAllHeroButtons()
    {
        // TODO: Filter heros by color, and so on

        foreach (var hero in Heroes)
        {
            if (hero.IsAlive)
            {
                hero.Button.gameObject.SetActive(true);
                hero.Outline.enabled = true;
                hero.Outline.ChangeOutlineColor(hero.Colors[0]);
            }

        }
    }
    
    private void TurnOnAllCachedButtons(ColorIdentity color)
    {
        foreach (var character in _potentialTargets)
        {
            if (character.IsAlive)
            {
                
                character.Button.gameObject.SetActive(true);
                character.Outline.enabled = true;
                character.Outline.ChangeOutlineColor(color);
            }
        }
    }

    public void TurnOffAllButtons()
    {
        foreach (var enemy in Enemies)
        {
            enemy.Button.gameObject.SetActive(false);
            enemy.Outline.enabled = false;
        }

        foreach (var hero in Heroes)
        {
            hero.Button.gameObject.SetActive(false);
            hero.Outline.enabled = false;
        }
    }

    #endregion

}
