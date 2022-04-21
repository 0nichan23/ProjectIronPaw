using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : Buff
{
    public Regen(Character host, int numberOfTurns) : base(host, numberOfTurns)
    {
        StatusEffectType = StatusEffectType.Regen;
        CustomConstructor(host, numberOfTurns);
    }
    protected override void Subscribe()
    {
        _host.OnStartTurn += Regening;
        _host.OnStartTurn += Countdown;
    }

    protected override void UnSubscribe()
    {
        _host.OnStartTurn -= Regening;
        _host.OnStartTurn -= Countdown;
    }

    public void Regening()
    {
        _host.Heal(TurnCounter);
    }
}
