using UnityEngine;

public class Taunt : Buff
{

    public Taunt(Character host, int numberOfTurns) : base(host)
    {

        StatusEffect statusEffect = CheckModifier(host);


        if (statusEffect == null)
        {
            TurnCounter = numberOfTurns;
            _host = host;
            InitializeStatusEffect();
        }
        else
        {
            ((Taunt)statusEffect).TurnCounter += numberOfTurns;
        }

    }

    protected override void Subscribe()
    {

        _host.OnStartTurn += TauntCountdown;
    }

    protected override void UnSubscribe()
    {
        _host.OnStartTurn -= TauntCountdown;
        RemoveModifierFromHost();
    }
    private void TauntCountdown()
    {
        TurnCounter--;
        if (TurnCounter <= 0)
        {
            UnSubscribe();
        }
    }
}


