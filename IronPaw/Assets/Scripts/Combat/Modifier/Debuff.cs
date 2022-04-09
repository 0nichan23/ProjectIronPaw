using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Debuff : StatusEffect
{
    public Debuff(Character host) : base(host)
    {
        _host = host;
    }
}
