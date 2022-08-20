using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : Buff
{
    private int _givenDamage;
    public Thorns(Character host, int numberOfTurns) : base(host, numberOfTurns)
    {
        StatusEffectType = StatusEffectType.Thorns;
        CustomConstructor(host, numberOfTurns);
    }

    protected override void Subscribe()
    {
        _host.OnTakeDamage += Retaliate;
        _host.OnStartTurn += Countdown;
    }

    protected override void UnSubscribe()
    {
        _host.OnTakeDamage -= Retaliate;
        _host.OnStartTurn -= Countdown;

    }

    private void Retaliate(Damage damage)
    {
        if(damage.IsSourceAttack)
        {
            damage.SourceCharacter.TakeDmg(new Damage(TurnCounter, _host, false));
        }
    }

}
