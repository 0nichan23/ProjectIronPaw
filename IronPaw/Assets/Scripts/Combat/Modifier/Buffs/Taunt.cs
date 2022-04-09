using UnityEngine;

public class Taunt : Buff
{
    private int _turnCounter;
    public int TurnCounter { get => _turnCounter; set => _turnCounter = value; }
    public Taunt(Character host, int numberOfTurns) : base(host)
    {

        StatusEffect modifier = CheckModifier(host);


        if (modifier == null)
        {
            
            TurnCounter = numberOfTurns;
            _host = host;
            Subscribe();
            Debug.Log(TurnCounter);
        }
        else
        {

            ((Taunt)modifier).TurnCounter += numberOfTurns;
            Debug.Log(((Taunt)modifier).TurnCounter);
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
        _turnCounter--;
        if (_turnCounter <= 0)
        {
            UnSubscribe();
        }
    }
}


