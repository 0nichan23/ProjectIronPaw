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
    }

    protected override void UnSubscribe()
    {
        _host.OnStartTurn -= Regening;
    }

    public void Regening()
    {
        _host.Heal(TurnCounter);
        TurnCounter--;
        if (TurnCounter <= 0)
        {
            RemoveStatusEffectFromHost();
        }
    }
}
