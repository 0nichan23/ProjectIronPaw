using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusEffectType
{
    NONE,
    Bleed, 
    Taunt,
    Regen,
    Thorns,
    Weak,
    Immune,
    Frail
}

public abstract class StatusEffect
{
    protected Character _host;

    private bool _newStatusEffect = true;

    public StatusEffectType StatusEffectType;

    private int _turnCounter;
    public int TurnCounter { get => _turnCounter; set => _turnCounter = value; }
    public bool NewStatusEffect { get => _newStatusEffect; }

    #region StatusEffectInitialization

    /*
     * Whenever the dev wants to create a new StatusEffect, they must use one of the CustomConstructor() functions.
       If they do, they must initialize the StatsEffect's StatusEffectType to anything that isn't the default (NONE),
       to make sure that checking for correct sprite to place
     */
    public StatusEffect(Character host)
    {

    }

    public StatusEffect(Character host, int numberOfTurns)
    {

    }

    protected void CustomConstructor(Character host)
    {
        BasicConstructorRequirments(host);
    }

    protected void CustomConstructor(Character host, int numberOfTurns)
    {
        BasicConstructorRequirments(host);

        StatusEffect statusEffect = CheckForExistingStatusEffectOfSameType(host);


        if (statusEffect == null)
        {
            TurnCounter = numberOfTurns;
            _host = host;
            InitializeStatusEffect();
        }
        else
        {
            statusEffect.TurnCounter += numberOfTurns;
            _newStatusEffect = false;
        }
    }

    private void BasicConstructorRequirments(Character host)
    {
        _host = host;

        if (StatusEffectType == StatusEffectType.NONE)
        {
            throw new NullReferenceException("Status Type Not Initialized!");
        }
    }

    protected StatusEffect CheckForExistingStatusEffectOfSameType(Character character)
    {
        Type A = this.GetType();
        foreach (var StatusEffect in character.ActiveStatusEffects)
        {
            Type B = StatusEffect.GetType();

            if (A == B)
            {
                return StatusEffect;
            }
        }
        return null;
    }

    protected void InitializeStatusEffect()
    {
        Subscribe();
    }
    #endregion

    protected void Countdown()
    {
        TurnCounter--;
        if (TurnCounter <= 0)
        {
            RemoveStatusEffectFromHost();
        }
    }

    protected void RemoveStatusEffectFromHost()
    {
        _host.ActiveStatusEffects.Remove(this);
        UnSubscribe();
    }

    protected abstract void Subscribe();

    protected abstract void UnSubscribe();
    
}
