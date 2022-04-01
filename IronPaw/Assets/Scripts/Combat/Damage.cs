using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{

    private Character _sourceCharacter;
    private bool _isSourceAttack;

    private int _givenDamage;

    public int FinalDamage 
    { 
        get
        {
            if(_isSourceAttack)
            {
                return _givenDamage + _sourceCharacter.Stats.Strength;
            }
            else
            {
                return _givenDamage;
            }
        }
    }

    public Damage(int givenDamage, Character playingCharacter)
    {
        _givenDamage = givenDamage;
        _sourceCharacter = playingCharacter;
    }
}
