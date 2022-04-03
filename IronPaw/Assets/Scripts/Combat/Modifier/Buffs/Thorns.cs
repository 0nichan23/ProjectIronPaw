using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : Buff
{
    private int _givenDamage;

    private int _turnCounter;

    public Thorns(Character host, int givenDamage) : base(host)
    {
        _host = host;
        _givenDamage = givenDamage;
        _turnCounter = 3;
        Subscribe();
    }

    protected override void Subscribe()
    {
        AddModifierToHost();
        _host.OnTakeDamage += Retaliate;
        _host.OnStartTurn += ThornsCountdown;
    }

    protected override void UnSubscribe()
    {
        RemoveModifierFromHost();
        _host.OnTakeDamage -= Retaliate;
        _host.OnStartTurn -= ThornsCountdown;
    }

    private void Retaliate(Damage damage)
    {
        if(damage.IsSourceAttack)
        {
            damage.SourceCharacter.TakeDmg(new Damage(_givenDamage, _host, false));
        }
    }

    private void ThornsCountdown()
    {
        _turnCounter--;
        if(_turnCounter <= 0)
        {
            UnSubscribe();
        }
    }
}
