using UnityEngine;

public class Taunt : Buff
{

    public Taunt(Character host, int numberOfTurns) : base(host, numberOfTurns)
    {
        StatusEffectType = StatusEffectType.Taunt;
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


