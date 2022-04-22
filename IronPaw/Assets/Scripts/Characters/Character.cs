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
    private bool _loseAllBlock = true;
    [SerializeField] private int _amountOfBlockToLose;
    [SerializeField] private int _currentAp;
    [SerializeField] private int _maxAp;


    [SerializeField] private CharacterSlot RefSlot;

    private List<StatusEffect> _activeStatusEffects = new List<StatusEffect>();

    public Action OnStartTurn;
    public Action OnEndTurn;
    public Action OnDeath;
    public Action<Damage> OnTakeDamage;

    public Button Button;

    [SerializeField] private Controller _controller;
    [SerializeField] private CharacterStats _stats = new CharacterStats();

    public int MaxHP { get => _maxHp; }
    public int CurrentHP { get => _currentHp; }
    public List<Color> Colors { get => colors; set => colors = value; }
    public int CurrentAp { get => _currentAp; set => _currentAp = value; }
    public string CharacterName { get => _characterName; set => _characterName = value; }
    public CharacterStats Stats { get => _stats; set => _stats = value; }
    public List<StatusEffect> ActiveStatusEffects { get => _activeStatusEffects; set => _activeStatusEffects = value; }
    public int MaxAp { get => _maxAp; set => _maxAp = value; }
    public Controller Controller { get => _controller; set => _controller = value; }
    public int CurrentBlock { get => _currentBlock; set => _currentBlock = value; }
    public int AmountOfBlockToLose
    {
        get => _amountOfBlockToLose;
        set
        {
            if(_loseAllBlock)
            {
                _loseAllBlock = false;
            }
            _amountOfBlockToLose = value;
        }
    }


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
        _currentHp = MaxHP;
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

    public void AddStatusEffect(StatusEffect statusEffect)
    {
        if(statusEffect.NewStatusEffect)
        {
            ActiveStatusEffects.Add(statusEffect);
        }
        //RefSlot.DisplayEffect(mod);
    }

    public void SelectCharacter()
    {
        PartyManager.Instance.SelectedCharacter = this;
    }

    public void GainBlock(int amount)
    {
        CurrentBlock += amount + Stats.Dexterity;
    }

    public void Heal(int amount, Character source)
    {
        _currentHp += amount + source.Stats.Faith;
        if (_currentHp >= MaxHP)
        {
            _currentHp = MaxHP;
        }
    }

    public void TakeDmg(Damage damage)
    {
        int amount;

        if (IsAfflictedBy(StatusEffectType.Immune))
        {
            amount = 0;
        }
        else
        {
            amount = damage.FinalDamage;

            if (damage.IsSourceAttack && IsAfflictedBy(StatusEffectType.Frail))
            {
                amount = (int)(amount * 1.5f);
            }
            
            if (CurrentBlock >= amount)
            {
                CurrentBlock -= amount;
            }
            else
            {
                int remainder = amount - CurrentBlock;
                CurrentBlock = 0;
                amount = remainder;

                _currentHp -= amount;

                OnTakeDamage?.Invoke(damage);

                if (_currentHp <= 0)
                {
                    _currentHp = 0;
                    Die();
                }
            }           
        }        
    }

    private void Die()
    {
        OnDeath?.Invoke();
        UnSubscribe();
    }

    private void StartOfTurnReset()
    {
        ClearBlock();
        RegainAP();
    }

    public void ClearBlock()
    {
        if(_loseAllBlock)
        {
            CurrentBlock = 0;
        }
        else
        {
            CurrentBlock -= AmountOfBlockToLose;
        }
    }

    private void RegainAP()
    {
        CurrentAp = MaxAp;
    }

    protected abstract void DetermineController();

    public bool IsAfflictedBy(StatusEffectType givenStatusEffectType)
    {
        foreach (StatusEffect StatusEffect in ActiveStatusEffects)
        {
            if (givenStatusEffectType == StatusEffect.StatusEffectType)
            {
                return true;
            }
        }
        return false;
    }
}
