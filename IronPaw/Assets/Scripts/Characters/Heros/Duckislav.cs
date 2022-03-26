using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duckislav : Hero
{

    protected override void TheBetterStart()
    {
        base.TheBetterStart();
        Bleed bleed = new Bleed(this, 2);
    }
    public override void Passive()
    {
        base.Passive();
    }
}
