using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{

    private Character _sourceCharacter;
    private bool _isSourceAttack;
    private int _givenDamage;
    private float _weakModifier = 1;

    public Character SourceCharacter { get => _sourceCharacter; }
    public bool IsSourceAttack { get => _isSourceAttack; }
    public int GivenDamage { get => _givenDamage; set => _givenDamage = value; }
    public int FinalDamage 
    { 
        get
        {
            if(IsSourceAttack)
            {
                if(SourceCharacter.IsAfflictedBy(StatusEffectType.Weak))
                {
                    _weakModifier = 0.67f;
                }
                return (int)((GivenDamage + SourceCharacter.Stats.Strength) * _weakModifier);
            }
            else
            {
                return GivenDamage;
            }
        }
    }


    public Damage(int givenDamage, Character playingCharacter, bool isSourceAttack = true)
    {
        GivenDamage = givenDamage;
        _sourceCharacter = playingCharacter;
        _isSourceAttack = isSourceAttack;
    }
}
