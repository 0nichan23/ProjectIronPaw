using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CharacterStats
{
    private int _strength;
    private int _dexterity;
    private int _intelligence;
    private int _faith;

    public int Strength { get => _strength; set => _strength = value; }
    public int Dexterity { get => _dexterity; set => _dexterity = value; }
    public int Intelligence { get => _intelligence; set => _intelligence = value; }
    public int Faith { get => _faith; set => _faith = value; }
}
