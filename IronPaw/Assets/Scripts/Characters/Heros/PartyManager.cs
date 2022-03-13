using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : Singleton<PartyManager>
{
    // an int that is null until it's set
    int? gogogo; 

    List<Hero> heros = new List<Hero>();

    public Hero SelectedHero;
    public IEnumerator WaitUntilHeroIsPicked(CardSO card)
    {
        
        yield return new WaitUntil(() => gogogo != null);
        SelectedHero = heros[(int)gogogo];
    }

    public void CheckIfCardIsValid(CardSO card)
    {
        foreach (var hero in heros)
        {
            foreach (var heroColor in hero.Colors)
            {
                foreach (var cardColor in card.Colors)
                {
                    if (heroColor == cardColor)
                    {
                        // selectable = true;
                    }
                }
            }
        }


    }

    public void SetHeroIndex(int givenIndex)
    {
        gogogo = givenIndex;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
