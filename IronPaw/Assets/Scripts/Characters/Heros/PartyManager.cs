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

    public IEnumerator WaitUntilTargetIsSelected (Character playingCharacter, CardSO card)
    {
        yield return new WaitUntil(() => SelectedCharacter != null);
        card.CardEffect.Targets.Add(SelectedCharacter);
        card.CardEffect.PlayEffect();
        card.RemoveCard(playingCharacter);
        SelectedCharacter = null;
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
                Character randomAlly = GoodGuys[rand.Next(0, GoodGuys.Count)];

                cardEffectRef.Targets.Add(randomAlly);
                cardEffectRef.PlayEffect();
                card.RemoveCard(playingCharacter);

                break;

            case TargetType.AllAllies:
                foreach (Character ally in GoodGuys)
                {
                    cardEffectRef.Targets.Add(ally);
                }
                cardEffectRef.PlayEffect();
                card.RemoveCard(playingCharacter);

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
                card.RemoveCard(playingCharacter);
                break;

            case TargetType.SingleEnemy:
                // set active true for all hero enemies buttons
                StartCoroutine(WaitUntilTargetIsSelected(playingCharacter, card));
                break;

            case TargetType.RandomEnemy:
                System.Random rand1 = new System.Random();
                Character randomEnemy = BadGuys[rand1.Next(0, BadGuys.Count)];

                cardEffectRef.Targets.Add(randomEnemy);

                cardEffectRef.PlayEffect();
                card.RemoveCard(playingCharacter);
                break;

            case TargetType.AllEnemies:

                foreach (Character enemy in BadGuys)
                {
                    cardEffectRef.Targets.Add(enemy);
                }
                cardEffectRef.PlayEffect();
                card.RemoveCard(playingCharacter);

                break;
        }

        

    }




}
