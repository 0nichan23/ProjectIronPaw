using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private List<Color> colors;
    [SerializeField] private int _maxHp;
    [SerializeField] private int _currentHp;
    [SerializeField] private int _currentBlock;
    [SerializeField] private string _characterName;
    private CharacterStats _stats;
    [SerializeField] private int _keepBlock;
    [SerializeField] private int currentAp;

    private List<Modifier> _activeModifiers = new List<Modifier>();

    public Action OnStartTurn;
    public Action OnEndTurn;
    public Action<Damage> OnTakeDamage;

    public Button Button;

    public int CurrentHP { get => _currentHp; }
    public List<Color> Colors { get => colors; set => colors = value; }
    public int CurrentAp { get => currentAp; set => currentAp = value; }
    public string CharacterName { get => _characterName; set => _characterName = value; }
    public CharacterStats Stats { get => _stats; set => _stats = value; }
    public List<Modifier> ActiveModifiers { get => _activeModifiers; set => _activeModifiers = value; }

    
    //List<Card> PersonalDeck;
    private void Start()
    {
        TheBetterStart();
        Subscribe();

    }

    protected virtual void TheBetterStart()
    {
        Button = GetComponent<Button>();
        _currentHp = _maxHp;
        OnStartTurn += ClearBlock;
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

    public void SelectCharacter()
    {
        PartyManager.Instance.SelectedCharacter = this;
        Debug.Log("Pls " + CharacterName);
    }

    public void GainBlock(int amount)
    {
        _currentBlock += amount;
    }

    public void ClearBlock()
    {
        _currentBlock = 0;
    }

    public void Heal(int amount)
    {
        _currentHp += amount;
        if (_currentHp >= _maxHp)
        {
            _currentHp = _maxHp;
        }
    }

    public void TakeDmg(Damage damage)
    {
        int amount = damage.FinalDamage;
        
        if (_currentBlock >= amount)
        {
            _currentBlock -= amount;
        }
        else
        {
            int remainder = amount - _currentBlock;
            _currentBlock = 0;
            amount = remainder;
        }
        _currentHp -= amount;

        if (_currentHp <= 0)
        {
            _currentHp = 0;
        }

        OnTakeDamage?.Invoke(damage);
    }
}
