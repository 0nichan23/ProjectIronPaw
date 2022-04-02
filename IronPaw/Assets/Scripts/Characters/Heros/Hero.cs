using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    private bool _selectable;

    public bool Selectable { get => _selectable; set => _selectable = value; }


    

    public override void Subscribe()
    {
        TurnManager.Instance.OnStartPlayerTurn += InvokeStartTurn;
        TurnManager.Instance.OnEndPlayerTurn += InvokeEndTurn;
    }
    public override void UnSubscribe()
    {
        TurnManager.Instance.OnStartPlayerTurn -= InvokeStartTurn;
        TurnManager.Instance.OnEndPlayerTurn -= InvokeEndTurn;
    }

    public virtual void Passive()
    {

    }

    public virtual void SubscribePassive()
    {

    }

    public virtual void Ultimate()
    {

    }



}
