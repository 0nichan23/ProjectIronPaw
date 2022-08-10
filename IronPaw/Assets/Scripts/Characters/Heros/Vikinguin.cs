using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vikinguin : HeroProfile
{
    [SerializeField] private int _numberOfTurnsToProccPassive = 3;
    private int _numberOfTurnsRemainingToPassiveProcc;
    [SerializeField] private int _amountOfBlockToGainFromPassive = 3;
    [SerializeField] private int _amountOfBlockToGainFromUltimate = 30;

    protected void Start()
    {
        _numberOfTurnsRemainingToPassiveProcc = _numberOfTurnsToProccPassive;
    }

    public override void SubscribePassive()
    {
        _character.OnStartTurn += VikinguinPassive;
    }
    public override void UnSubscribePassive()
    {
        _character.OnStartTurn -= VikinguinPassive;
    }

    private void VikinguinPassive()
    {
        if (_numberOfTurnsRemainingToPassiveProcc == 0)
        {
            AudioManager.Instance.Play(AudioManager.Instance.SfxClips[9]);
            _character.GainBlock(_amountOfBlockToGainFromPassive);
            _character.AddStatusEffect(new Taunt(_character, 1));
            _numberOfTurnsRemainingToPassiveProcc = _numberOfTurnsToProccPassive;
        }

        _numberOfTurnsRemainingToPassiveProcc--;   
    }

    public override void Ultimate()
    {
        _character.Animator.SetTrigger("Ult");
        _character.GainBlock(_amountOfBlockToGainFromUltimate);
        _character.AddStatusEffect(new Taunt(_character, 3));
        _character.AmountOfBlockToLose = 10;
    }

}
