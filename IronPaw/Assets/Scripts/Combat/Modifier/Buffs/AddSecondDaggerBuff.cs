using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSecondDaggerBuff : Buff
{
    private CardScriptableObject _cardToAddToHand;

    public AddSecondDaggerBuff(Character host, int numberOfTurns, CardScriptableObject cardToAddToHand) : base(host, numberOfTurns)
    {
        StatusEffectType = StatusEffectType.AddSecondDaggerBuff;
        CustomConstructor(host, numberOfTurns);
        _cardToAddToHand = cardToAddToHand;
        if(_cardToAddToHand.CardName != "Second Dagger")
        {
            throw new NullReferenceException("Card is not valid!");
        }
    }
    protected override void Subscribe()
    {
        _host.OnStartTurn += AddSecondDaggers;
        _host.OnStartTurn += Countdown;
    }

    protected override void UnSubscribe()
    {
        _host.OnStartTurn -= AddSecondDaggers;
        _host.OnStartTurn -= Countdown;
    }

    public void AddSecondDaggers()
    {
        while (TurnCounter > 0)
        {
            _cardToAddToHand.GenerateCard(_host);
            TurnCounter--;
        }        
    }
}
