using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sima : Hero
{
    [SerializeField] private int _passiveHealAmount = 2;
    [SerializeField] private int _ultimateHealAmount = 6;


   

    public override void Ultimate()
    {
        foreach (var hero in Controller.ControllerChracters)
        {
            hero.Heal(_ultimateHealAmount, this);
        }
    }

    private void SimaPassive()
    {
        List<Character> damagedHeroes = new List<Character>();

        foreach (var hero in Controller.ControllerChracters)
        {
            if (hero.CurrentHP < hero.MaxHP)
            {
                damagedHeroes.Add(hero);
            }
        }

        if (damagedHeroes.Count == 0)
        {
            return;
        }

        Character randomHero = damagedHeroes[new System.Random().Next(0, damagedHeroes.Count)];
        randomHero.Heal(_passiveHealAmount, this);
    }

    public override void SubscribePassive()
    {
        ExiledPile.OnCardAdded+= SimaPassive;
    }

    public override void UnSubscribePassive()
    {
        ExiledPile.OnCardAdded -= SimaPassive;
    }

    
}
