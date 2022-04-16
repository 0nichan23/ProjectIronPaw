using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModifierType
{
    Bleed, 
    Taunt,
    Regen
}

public abstract class StatusEffect
{
    protected Character _host;

    public ModifierType ModType;

    public StatusEffect(Character host)
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
    protected StatusEffect CheckModifier(Character character)
    {
        Type A = this.GetType();
        foreach (var modifier in character.ActiveModifiers)
        {
            Type B = modifier.GetType();
            
            if (A == B)
            {
                Debug.Log(A);
                return modifier;
            }
        }
        return null;
    }
}
