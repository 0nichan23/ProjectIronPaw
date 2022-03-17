using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : Singleton<PartyManager>
{
    // an int that is null until it's set
    int? gogogo; 

    List<Hero> heros = new List<Hero>();

    public Hero SelectedHero;

    public IEnumerator WaitUntilHeroIsClicked(CardSO card)
    {
        yield return new WaitUntil(() => SelectedHero != null);

        if (CheckCardAndHeroColors(card, SelectedHero))
        {
            card.PlayCard(SelectedHero);
            SelectedHero = null;
        }
        else
        {
            Debug.Log("Invalid Card / Hero");
        }    
    }

    public IEnumerator WaitUntilHeroIsPicked(CardSO card)
    {
        yield return new WaitUntil(() => gogogo != null);
        SelectedHero = heros[(int)gogogo];

        //if (SelectedHero.Selectable)
        //{
        //    card.PlayCard(SelectedHero);
        //}
        //else
        //{
        //    SelectedHero = null;
        //    Debug.Log("Invalid hero");
        //}
    }

    public bool CheckCardAndHeroColors(CardSO card, Hero hero)
    {
        foreach (Color heroColor in hero.Colors)
        {
            foreach (var cardColor in card.Colors)
            {
                if (heroColor == cardColor)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void SetHeroIndex(int givenIndex)
    {
        gogogo = givenIndex;
    }
}
