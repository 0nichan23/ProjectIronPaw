using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{

    private Character _sourceCharacter;
    private bool _isSourceAttack;

    private int _givenDamage;

    public int GivenDamage { get => _givenDamage; set => _givenDamage = value; }

    public int FinalDamage 
    { 
        get
        {
            if(IsSourceAttack)
            {
                return GivenDamage + SourceCharacter.Stats.Strength;
            }
            else
            {
                return GivenDamage;
            }
        }
    }

    public bool IsSourceAttack { get => _isSourceAttack; }
    public Character SourceCharacter { get => _sourceCharacter; }

    public Damage(int givenDamage, Character playingCharacter, bool isSourceAttack = true)
    {
        GivenDamage = givenDamage;
        _sourceCharacter = playingCharacter;
        _isSourceAttack = isSourceAttack;
    }
}
