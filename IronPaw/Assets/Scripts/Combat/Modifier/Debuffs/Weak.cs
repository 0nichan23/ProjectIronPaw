using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weak : Debuff
{
    public Weak(Character host, int numberOfTurns) : base(host, numberOfTurns)
    {
        StatusEffectType = StatusEffectType.Weak;
        CustomConstructor(host, numberOfTurns);
    }

    protected override void Subscribe()
    {
        _host.OnEndTurn += Countdown;
    }

    protected override void UnSubscribe()
    {
        _host.OnEndTurn -= Countdown;
    }
}
