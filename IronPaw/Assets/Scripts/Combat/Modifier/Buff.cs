using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : StatusEffect
{
    public Buff(Character host) : base(host)
    {

    }

    public Buff(Character host, int numberOfTurns) : base(host, numberOfTurns)
    {

    }
}
