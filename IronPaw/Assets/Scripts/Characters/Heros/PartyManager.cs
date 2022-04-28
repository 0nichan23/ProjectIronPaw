using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyManager : Singleton<PartyManager>
{
    public List<Character> Heroes;
    public List<Character> Enemies;

    

    [SerializeField] private List<Character> _pointerList;

    private List<Character> _potentialTargets;

    public Character SelectedCharacter;

    [SerializeField] private GameObject _selectionCanvas;

    private void Start()
    {
        Enemies = EnemyWrapper.Instance.EnemyController.ControllerChracters;
        Heroes = PlayerWrapper.Instance.PlayerController.ControllerChracters;
        _potentialTargets = new List<Character>();
    }
    
    public void SelectHeroToUltimate()
    {
        StartCoroutine(WaitUntilHeroIsClickedUltimate());
    }

    private IEnumerator WaitUntilHeroIsClickedUltimate()
    {
        ToggleSelectionCanvas(true);
        TurnOnAllHeroButtons();

        yield return new WaitUntil(() => SelectedCharacter != null);
        ToggleSelectionCanvas(false);
        ((Hero)SelectedCharacter).PerformUltimate();
    }

    public IEnumerator WaitUntilHeroIsClickedPlayCard(CardScriptableObject card)
    {
        ToggleSelectionCanvas(true);
        yield return new WaitUntil(() => SelectedCharacter != null);        
        PlayCard(SelectedCharacter, card);
    }

    public IEnumerator WaitUntilTargetIsSelected (Character playingCharacter, CardScriptableObject card, CardEffect cardEffectRef, CardUI cardUI)
    {
        yield return new WaitUntil(() => SelectedCharacter != null);
        
        cardEffectRef.Targets.Add(SelectedCharacter);
        PlayEffectAndCleanUp(playingCharacter, card, cardEffectRef, cardUI);
        SelectedCharacter = null;
    }

    public void PlayCard(Character playingCharacter, CardScriptableObject card)
    {
        ClearCachedCharacters();
        TurnOffAllButtons(); // Turns off the button of playingCharacter
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
                PlayEffectAndCleanUp(playingCharacter, card, cardEffectRef, cardUI);
                break;

            case TargetType.SingleHero:
                // set active true for all hero allies buttons
                FillLegalTargets(playingCharacter, card, Heroes);
                TurnOnAllCachedButtons();
                StartCoroutine(WaitUntilTargetIsSelected(playingCharacter, card, cardEffectRef, cardUI));
                break;

            case TargetType.RandomHero:
                System.Random rand = new System.Random();
                FillLegalTargets(playingCharacter, card, Heroes);
                Character randomHero = _potentialTargets[rand.Next(0, _potentialTargets.Count)];
                cardEffectRef.Targets.Add(randomHero);
                PlayEffectAndCleanUp(playingCharacter, card, cardEffectRef, cardUI);
                break;

            case TargetType.AllHeroes:
                foreach (Character ally in Heroes)
                {
                    cardEffectRef.Targets.Add(ally);
                }
                PlayEffectAndCleanUp(playingCharacter, card, cardEffectRef, cardUI);
                break;

            case TargetType.AllHeroesButMe:
                foreach (Character ally in Heroes)
                {
                    if(ally != playingCharacter)
                    {
                        cardEffectRef.Targets.Add(ally);
                    }                 
                }
                PlayEffectAndCleanUp(playingCharacter, card, cardEffectRef, cardUI);

                break;

            case TargetType.SingleEnemy:
                // set active true for all hero enemies buttons
                FillLegalTargets(playingCharacter, card, Enemies);
                TurnOnAllCachedButtons();
                StartCoroutine(WaitUntilTargetIsSelected(playingCharacter, card, cardEffectRef, cardUI));
                break;

            case TargetType.RandomEnemy:
                System.Random rand1 = new System.Random();
                FillLegalTargets(playingCharacter, card, Enemies);
                Character randomEnemy = _potentialTargets[rand1.Next(0, _potentialTargets.Count)];
                cardEffectRef.Targets.Add(randomEnemy);
                PlayEffectAndCleanUp(playingCharacter, card, cardEffectRef, cardUI);

                break;

            case TargetType.AllEnemies:
                foreach (Character enemy in Enemies)
                {
                    cardEffectRef.Targets.Add(enemy);
                }
                PlayEffectAndCleanUp(playingCharacter, card, cardEffectRef, cardUI);
                break;
        }

        
    }

    private void ClearCachedCharacters()
    {
        _potentialTargets.Clear();
    }

    private void FillLegalTargets(Character playingCharacter, CardScriptableObject card, List<Character> targetList)
    {
        _pointerList = targetList;

        if (card.CardType == CardType.Attack)
        {
            foreach (var character in _pointerList)
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
            foreach (var item in _pointerList)
            {
                _potentialTargets.Add(item);
            }
        }

        _pointerList = null;
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

    public void CancelCard()
    {
        StopCoroutine("WaitUntilHeroIsClickedPlayCard");
        StopCoroutine("WaitUntilHeroIsClickedUltimate");
        StopCoroutine("WaitUntilTargetIsSelected");
        SelectedCharacter = null;
        _pointerList = null;
        TurnOffAllButtons();
        ClearCachedCharacters();
        ToggleSelectionCanvas(false);
    }

    private void ToggleSelectionCanvas(bool state)
    {
        _selectionCanvas.SetActive(state);
    }

    private void PlayEffectAndCleanUp(Character playingCharacter, CardScriptableObject card, CardEffect cardEffectRef, CardUI cardUI)
    {
        cardEffectRef.PlayEffect(playingCharacter, card);
        card.RemoveCard(playingCharacter);
        if(cardUI != null)
        {
            cardUI.DestroyTheHeretic();
        }        
        TurnOffAllButtons();
        ToggleSelectionCanvas(false);
    }

}
