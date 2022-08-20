using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sima : HeroProfile
{
    [SerializeField] private int _passiveHealAmount = 2;
    [SerializeField] private int _ultimateHealAmount = 6;


   

    public override void Ultimate()
    {
        _character.Animator.SetTrigger("Ult");
        foreach (var hero in CombatManager.Instance.Heroes)
        {
            hero.Heal(_ultimateHealAmount, _character);

        }
    }

    private void SimaPassive()
    {
        List<Character> damagedHeroes = new List<Character>();

        foreach (var hero in _character.Controller.ControllerChracters)
        {
            if (hero.IsAlive && hero.CurrentHP < hero.MaxHP)
            {
                damagedHeroes.Add(hero);
            }
        }

        if (damagedHeroes.Count == 0)
        {
            return;
        }
        AudioManager.Instance.Play(AudioManager.Instance.SfxClips[9]);
        Character randomHero = damagedHeroes[new System.Random().Next(0, damagedHeroes.Count)];
        randomHero.Heal(_passiveHealAmount, _character);
    }

    public override void SubscribePassive()
    {
        _character.ExiledPile.OnCardAdded+= SimaPassive;
    }

    public override void UnSubscribePassive()
    {
        _character.ExiledPile.OnCardAdded -= SimaPassive;
    }

    
}
