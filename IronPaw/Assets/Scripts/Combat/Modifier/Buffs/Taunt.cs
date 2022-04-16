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

        _host.OnStartTurn += TauntCountdown;
    }

    protected override void UnSubscribe()
    {
        _host.OnStartTurn -= TauntCountdown;
    }
    private void TauntCountdown()
    {
        TurnCounter--;
        if (TurnCounter <= 0)
        {
            RemoveStatusEffectFromHost();
        }
    }
}


