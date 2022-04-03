using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Debuff : Modifier
{
    public Debuff(Character host) : base(host)
    {
        _host = host;
    }
}
