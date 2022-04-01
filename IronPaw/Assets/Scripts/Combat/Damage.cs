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
            if(_isSourceAttack)
            {
                return GivenDamage + _sourceCharacter.Stats.Strength;
            }
            else
            {
                return GivenDamage;
            }
        }
    }

    public Damage(int givenDamage, Character playingCharacter)
    {
        GivenDamage = givenDamage;
        _sourceCharacter = playingCharacter;
    }
}
