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
        yield return new WaitUntil(() => SelectedCharacter != null);
        Debug.Log(SelectedCharacter + " was selected");
        card.PlayCard(SelectedCharacter);
        SelectedCharacter = null;
    }

    public IEnumerator WaitUntilTargetIsSelected (Character playingCharacter, CardSO card)
    {
        yield return new WaitUntil(() => SelectedCharacter != null);
        card.CardEffect.Targets.Add(SelectedCharacter);
        card.CardEffect.PlayEffect();
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
                cardEffectRef.PlayEffect();
                card.RemoveCard(playingCharacter);
                break;

            case TargetType.SingleAlly:
                // enemies will need some sort of "if" statement to not wait for a coroutine, cuz they pick random targets or something

                // set active true for all hero allies buttons
                StartCoroutine(WaitUntilTargetIsSelected(playingCharacter, card));
                break;

            case TargetType.RandomAlly:
                System.Random rand = new System.Random();
                Character randomAlly = Heros[rand.Next(0, Heros.Count)];

                cardEffectRef.Targets.Add(randomAlly);
                cardEffectRef.PlayEffect();
                card.RemoveCard(playingCharacter);

                break;

            case TargetType.AllAllies:
                foreach (Character ally in Heros)
                {
                    cardEffectRef.Targets.Add(ally);
                }
                cardEffectRef.PlayEffect();
                card.RemoveCard(playingCharacter);

                break;

            case TargetType.AllAlliesButMe:
                foreach (Character ally in Heros)
                {
                    if(ally != playingCharacter)
                    {
                        cardEffectRef.Targets.Add(ally);
                    }                 
                }
                cardEffectRef.PlayEffect();
                card.RemoveCard(playingCharacter);
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

                cardEffectRef.PlayEffect();
                card.RemoveCard(playingCharacter);
                break;

            case TargetType.AllEnemies:

                foreach (Character enemy in Enemies)
                {
                    cardEffectRef.Targets.Add(enemy);
                }
                cardEffectRef.PlayEffect();
                card.RemoveCard(playingCharacter);

                break;
        }

        

    }

    private void TurnOnAllEnemyButtons()
    {
        foreach (var enemy in Enemies)
        {
            enemy.gameObject.GetComponent<Button>().enabled = true;
        }
    }

    private void TurnOffAllButtons()
    {
        foreach (var enemy in Enemies)
        {
            enemy.gameObject.GetComponent<Button>().enabled = false;
        }

        foreach (var hero in Heros)
        {
            hero.gameObject.GetComponent<Button>().enabled = false;
        }
    }




}
