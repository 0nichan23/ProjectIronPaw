using System;
using UnityEngine;

public class AddSecondDaggerBuff : Buff
{
    private GameObject _cardToAddToHand;
    private Card _cardAddedToHandRef;

    public AddSecondDaggerBuff(Character host, int numberOfTurns, GameObject cardToAddToHand) : base(host, numberOfTurns)
    {
        StatusEffectType = StatusEffectType.AddSecondDaggerBuff;
        CustomConstructor(host, numberOfTurns);
        _cardToAddToHand = cardToAddToHand;

#if UNITY_EDITOR
        if (_cardToAddToHand.GetComponent<Card>().CardName != "Second Dagger")
        {
            throw new NullReferenceException("Card Generated Isn't Valid!");
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif
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
            //_cardToAddToHand.GenerateCard(_host);
            // TODO: Create GenerateCard() func in Hand Class
            TurnCounter--;
        }        
    }
}
