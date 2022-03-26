using System.Collections.Generic;
using UnityEngine;
using System;

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
    private int currentAp;

    public Action OnStartTurn;
    public Action OnEndTurn;

    //Dictionary<ModifierType, int> _activeModifiers;
    //List<Card> PersonalDeck;
    private void Start()
    {
        TheBetterStart();
        Subscribe();

    }
    protected virtual void TheBetterStart()
    {

    }

    protected void InvokeStartTurn()
    {
        OnStartTurn?.Invoke();
    }
    protected void InvokeEndTurn()
    {
        OnEndTurn?.Invoke();
    }
    public abstract void Subscribe();

    public abstract void UnSubscribe();

    public List<Color> Colors { get => colors; set => colors = value; }
    public int CurrentAp { get => currentAp; set => currentAp = value; }

    public abstract void TakeDmg(int amount);
    public abstract void Heal(int amount);
    public abstract void GainBlock(int amount);
    public abstract void ClearBlock();

}
