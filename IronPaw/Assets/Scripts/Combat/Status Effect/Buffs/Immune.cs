using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immune : Buff
{

    public Immune(Character host, int numberOfTurns) : base(host, numberOfTurns)
    {
        StatusEffectType = StatusEffectType.Immune;
        CustomConstructor(host, numberOfTurns);
    }

    protected override void Subscribe()
    {
        _host.OnStartTurn += Countdown;
    }

    protected override void UnSubscribe()
    {
        _host.OnStartTurn -= Countdown;
    }
}
