using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Modifier
{
    protected Character _host;

    public Modifier(Character host)
    {
        _host = host;
    }

    protected void AddModifierToHost()
    {
        _host.ActiveModifiers.Add(this);
    }

    protected void RemoveModifierFromHost()
    {
        _host.ActiveModifiers.Remove(this);
    }

    protected abstract void Subscribe();

    protected abstract void UnSubscribe();
}
