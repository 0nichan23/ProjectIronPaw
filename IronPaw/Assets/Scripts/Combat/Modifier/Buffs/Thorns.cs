using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : Buff
{
    private int _givenDamage;
    public Thorns(Character host, int numberOfTurns, int givenDamage) : base(host, numberOfTurns)
    {
        _givenDamage = givenDamage;
        StatusEffectType = StatusEffectType.Thorns;
        CustomConstructor(host, numberOfTurns);
    }

    protected override void Subscribe()
    {
        _host.OnTakeDamage += Retaliate;
        _host.OnStartTurn += ThornsCountdown;
    }

    protected override void UnSubscribe()
    {
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
        TurnCounter--;
        if(TurnCounter <= 0)
        {
            RemoveStatusEffectFromHost();
        }
    }
}
