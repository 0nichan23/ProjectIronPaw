using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frail : Debuff
{
    public Frail(Character host, int numberOfTurns) : base(host, numberOfTurns)
    {
        StatusEffectType = StatusEffectType.Frail;
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
