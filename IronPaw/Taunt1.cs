using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taunt : Buff
{
    private int _turnCounter;
  
       public Taunt(Character host, int numbersOfTurns) : base(host)
    {
        _host = host;
        _turnCounter = numbersOfTurns;
        Subscribe();
    }

    protected override void Subscribe()
    {
        AddModifierToHost();
    }

    protected override void UnSubscribe()
    {
       
    }
}
