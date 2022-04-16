using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : Buff
{
    private int _givenRegen;
    public Regen(Character host, int givenRegen) : base(host)
    {
        ModType = ModifierType.Regen;
        _host = host;
        _givenRegen = givenRegen;
        Subscribe();
    }
    protected override void Subscribe()
    {
        AddModifierToHost();
        _host.OnStartTurn += Regening;
    }

    protected override void UnSubscribe()
    {
        RemoveModifierFromHost();
        _host.OnStartTurn -= Regening;
    }
    public void Regening()
    {
       
        _host.Heal(_givenRegen);
        _givenRegen--;
        if (_givenRegen <= 0)
        {
            UnSubscribe();
        }
    }
}
