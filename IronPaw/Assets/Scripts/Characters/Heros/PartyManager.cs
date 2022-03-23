using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : Singleton<PartyManager>
{
    public List<Character> GoodGuys = new List<Character>();
    public List<Character> BadGuys = new List<Character>();

    public Character SelectedCharacter;

    public IEnumerator WaitUntilHeroIsClickedPlayCard(CardSO card/*, Event func*/)
    {
        yield return new WaitUntil(() => SelectedCharacter != null);
        Debug.Log(SelectedCharacter + " was selected");
        card.PlayCard(SelectedCharacter);
        SelectedCharacter = null;
    }

    public IEnumerator WaitUntilTargetIsSelected (CardEffect cardEffect)
    {
        yield return new WaitUntil(() => SelectedCharacter != null);

        cardEffect.Targets.Add(SelectedCharacter);

        cardEffect.PlayEffect();

        SelectedCharacter = null;


    }

    public void PickTargets(Character playingCharacter, CardSO card)
    {
        CardEffect cardEffectRef = card.CardEffect;

        switch (cardEffectRef.TargetType)
        {
            case TargetType.Self:
                cardEffectRef.Targets.Add(playingCharacter);
                cardEffectRef.PlayEffect();
                break;

            case TargetType.SingleAlly:
                // enemies will need some sort of "if" statement to not wait for a coroutine, cuz they pick random targets or something

                // set active true for all hero allies buttons
                StartCoroutine(WaitUntilTargetIsSelected(cardEffectRef));
                break;

            case TargetType.RandomAlly:
                System.Random rand = new System.Random();
                Character randomAlly = GoodGuys[rand.Next(0, GoodGuys.Count)];

                cardEffectRef.Targets.Add(randomAlly);

                cardEffectRef.PlayEffect();

                break;

            case TargetType.AllAllies:
                foreach (Character ally in GoodGuys)
                {
                    cardEffectRef.Targets.Add(ally);
                }
                cardEffectRef.PlayEffect();

                break;

            case TargetType.AllAlliesButMe:
                foreach (Character ally in GoodGuys)
                {
                    if(ally != playingCharacter)
                    {
                        cardEffectRef.Targets.Add(ally);
                    }                 
                }
                cardEffectRef.PlayEffect();
                break;

            case TargetType.SingleEnemy:
                // set active true for all hero enemies buttons
                StartCoroutine(WaitUntilTargetIsSelected(cardEffectRef));
                break;

            case TargetType.RandomEnemy:
                System.Random rand1 = new System.Random();
                Character randomEnemy = BadGuys[rand1.Next(0, BadGuys.Count)];

                cardEffectRef.Targets.Add(randomEnemy);

                cardEffectRef.PlayEffect();
                break;

            case TargetType.AllEnemies:

                foreach (Character enemy in BadGuys)
                {
                    cardEffectRef.Targets.Add(enemy);
                }
                cardEffectRef.PlayEffect();

                break;
        }
    }




}
