using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private List<Color> colors;
    protected int _maxHp;
    protected int _currentHp;
    protected int _currentBlock;
    protected string _name;
    //protected CharacterStats _stats;
    protected int _keepBlock;
    protected int _currentAp;



    //Dictionary<ModifierType, int> _activeModifiers;
    //List<Card> PersonalDeck;


    public List<Color> Colors { get => colors; set => colors = value; }


    public abstract void TakeDmg(int amount);
    public abstract void Heal(int amount);
    public abstract void GainBlock(int amount);
    public abstract void ClearBlock();

}
