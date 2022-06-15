using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vikinguin : Hero
{
    [SerializeField] private int _numberOfTurnsToProccPassive = 3;
    private int _numberOfTurnsRemainingToPassiveProcc;
    [SerializeField] private int _amountOfBlockToGainFromPassive = 3;
    [SerializeField] private int _amountOfBlockToGainFromUltimate = 30;

    protected override void TheBetterStart()
    {
        base.TheBetterStart();
        _numberOfTurnsRemainingToPassiveProcc = _numberOfTurnsToProccPassive;
       
    }

    public override void SubscribePassive()
    {
        OnStartTurn += VikinguinPassive;
    }
    public override void UnSubscribePassive()
    {
        OnStartTurn -= VikinguinPassive;
    }

    private void VikinguinPassive()
    {
        if (_numberOfTurnsRemainingToPassiveProcc == 0)
        {
            GainBlock(_amountOfBlockToGainFromPassive);
            AddStatusEffect(new Taunt(this, 1));
            _numberOfTurnsRemainingToPassiveProcc = _numberOfTurnsToProccPassive;
        }

        _numberOfTurnsRemainingToPassiveProcc--;   
    }

    public override void Ultimate()
    {
        _animator.SetTrigger("Ult");
        GainBlock(_amountOfBlockToGainFromUltimate);
        AddStatusEffect(new Taunt(this, 3));
        AmountOfBlockToLose = 10;
    }

}
