using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sima : Hero
{
    [SerializeField] private int _ultimateHealAmount = 6;
    public override void SubscribePassive()
    {
        
    }

    public override void Ultimate()
    {
        foreach (var hero in Controller.ControllerChracters)
        {
            hero.Heal(_ultimateHealAmount, this);
        }
    }

    public override void UnSubscribePassive()
    {
        
    }
}
