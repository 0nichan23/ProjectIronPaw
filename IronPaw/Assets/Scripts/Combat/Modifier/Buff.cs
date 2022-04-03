using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : Modifier
{
   public Buff(Character host) : base(host)
   {
        _host = host;
   }
}
