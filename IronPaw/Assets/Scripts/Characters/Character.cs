using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    public Deck Deck;
    public DiscardPile DiscardPile;
    public ExiledPile ExiledPile;
    public Hand Hand;

    [SerializeField] private List<Color> colors;
    [SerializeField] private int _maxHp;
    [SerializeField] private int _currentHp;
    [SerializeField] private int _currentBlock;
    [SerializeField] private string _characterName;
    private CharacterStats _stats;
    [SerializeField] private int _keepBlock;
    [SerializeField] private int _currentAp;
    [SerializeField] private int _maxAp;


    [SerializeField]
    CharacterSlot RefSlot;

    private List<StatusEffect> _activeModifiers = new List<StatusEffect>();

    public Action OnStartTurn;
    public Action OnEndTurn;
    public Action<Damage> OnTakeDamage;

    public Button Button;

    [SerializeField] private Controller _controller;

    public int CurrentHP { get => _currentHp; }
    public List<Color> Colors { get => colors; set => colors = value; }
    public int CurrentAp { get => _currentAp; set => _currentAp = value; }
    public string CharacterName { get => _characterName; set => _characterName = value; }
    public CharacterStats Stats { get => _stats; set => _stats = value; }
    public List<StatusEffect> ActiveModifiers { get => _activeModifiers; set => _activeModifiers = value; }
    public int MaxAp { get => _maxAp; set => _maxAp = value; }
    public Controller Controller { get => _controller; set => _controller = value; }


    //List<Card> PersonalDeck;
    private void Start()
    {
        TheBetterStart();
        Subscribe();

    }

    protected virtual void TheBetterStart()
    {
        Button = GetComponentInChildren<Button>();
        RefSlot = GetComponent<CharacterSlot>();
        _currentHp = _maxHp;
        OnStartTurn += StartOfTurnReset;
        DetermineController();
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


    public void AddModifer(StatusEffect statusEffect)
    {
        ActiveModifiers.Add(statusEffect);
        //RefSlot.DisplayEffect(mod);
    }

    public void SelectCharacter()
    {
        PartyManager.Instance.SelectedCharacter = this;
    }

    public void GainBlock(int amount)
    {
        _currentBlock += amount;
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

    private void StartOfTurnReset()
    {
        ClearBlock();
        Regenerate();
    }

    public void ClearBlock()
    {
        _currentBlock = 0;
    }

    private void Regenerate()
    {
        CurrentAp = MaxAp;
    }

    protected abstract void DetermineController();
}
