using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    public Deck Deck;
    public DiscardPile DiscardPile;
    public ExiledPile ExiledPile;
    public Hand Hand;

    [SerializeField] private List<ColorIdentity> colors;
    [SerializeField] private int _maxHp;
    [SerializeField] private int _currentHp;
    [SerializeField] private int _currentBlock;
    [SerializeField] private string _characterName;
    private bool _loseAllBlock = true;
    [SerializeField] private int _amountOfBlockToLose;
    [SerializeField] private int _currentAp;
    [SerializeField] private int _maxAp;

    [SerializeField] private CharacterPersonalUI _refSlot;

    [SerializeField] protected Animator _animator;
    [SerializeField] private bool _reachedAnimationSyncFrame;
    public AnimationEvent AnimationSyncEvent;

    [SerializeField] private string _passiveDescription;
    [SerializeField] private string _ultimateDescription;

    public bool DoneDying;

    private List<StatusEffect> _activeStatusEffects = new List<StatusEffect>();

    public Action OnStartTurn;
    public Action OnEndTurn;
    public Action OnRecieveTaunt;
    public Action OnDeath;
    public Action<Damage> OnTakeDamage;

    public Button Button;
    public Sprite CharacterSprite;

    [SerializeField] private Controller _controller;
    [SerializeField] private CharacterStats _stats = new CharacterStats();
   

    public int MaxHP { get => _maxHp; }
    public int CurrentHP { get => _currentHp; }
    public List<ColorIdentity> Colors { get => colors; set => colors = value; }
    public int CurrentAp
    {
        get => _currentAp;
        set
        { 
            _currentAp = value;
            UpdateUI();
        }
    }
    public string CharacterName { get => _characterName; set => _characterName = value; }
    public CharacterStats Stats { get => _stats; set => _stats = value; }
    public List<StatusEffect> ActiveStatusEffects { get => _activeStatusEffects; set => _activeStatusEffects = value; }
    public int MaxAp { get => _maxAp; set => _maxAp = value; }
    public Controller Controller { get => _controller; set => _controller = value; }
    public int CurrentBlock { get => _currentBlock; set => _currentBlock = value; }
    public CharacterPersonalUI RefSlot { get => _refSlot; set => _refSlot = value; }

    public bool IsAlive = true;

    public Outline Outline;

    public int AmountOfBlockToLose
    {
        get => _amountOfBlockToLose;
        set
        {
            if (_loseAllBlock)
            {
                _loseAllBlock = false;
            }
            _amountOfBlockToLose = value;
        }
    }

    public bool ReachedAnimationSyncFrame { get => _reachedAnimationSyncFrame; set => _reachedAnimationSyncFrame = value; }
    public string PassiveDescription { get => _passiveDescription; set => _passiveDescription = value; }
    public string UltimateDescription { get => _ultimateDescription; set => _ultimateDescription = value; }

    private void Start()
    {
        TheBetterStart();
        Subscribe();
    }

    protected virtual void TheBetterStart()
    {
        Outline = GetComponentInParent<Outline>();
        RefSlot = GetComponentInChildren<CharacterPersonalUI>();
        _currentHp = MaxHP;
        OnStartTurn += StartOfTurnReset;
        StartOfTurnReset();
        DetermineController();
        UpdateUI();
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
        if (statusEffect.NewStatusEffect)
        {
            ActiveStatusEffects.Add(statusEffect);
            if (statusEffect is Taunt)
            {
                OnRecieveTaunt?.Invoke();
            }
        }
        if (RefSlot != null)
        {
            RefSlot.AddEffect(statusEffect);
        }
        UpdateUI();
    }

    public virtual void UpdateUI()
    {
        if (RefSlot != null)
        {
            RefSlot.SetupCanvas(this);
            RefSlot.UpdateStatuses();
            RefSlot.UpdateHpBar(MaxHP, CurrentHP);
            RefSlot.UpdateBlock(CurrentBlock);
            RefSlot.UpdateActionPoint(_maxAp, _currentAp);
        }
    }

    public void SelectCharacter()
    {
        PartyManager.Instance.SelectedCharacter = this;
    }

    public void GainBlock(int amount)
    {
        CurrentBlock += amount + Stats.Dexterity;
        UpdateUI();
    }

    public void Heal(int amount, Character source)
    {
        _currentHp += amount + source.Stats.Faith;
        if (_currentHp >= MaxHP)
        {
            _currentHp = MaxHP;
        }
        UpdateUI();
        VFXManager.Instance.CreateHealingPopup(transform.position, amount);
        VFXManager.Instance.CreateHealingParticle(transform.position);

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
        }

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
            int hpToLose = remainder;

            _currentHp -= hpToLose;
            _animator.SetTrigger("Hit");
            OnTakeDamage?.Invoke(damage);

            if (_currentHp <= 0)
            {
                _currentHp = 0;
                Die();
            }
        }
        if(damage.IsSourceAttack)
        {
            VFXManager.Instance.CameraShake.ShakeCameraForSeconds(0.7f);
        }
        UpdateUI();
        VFXManager.Instance.CreateDamagePopup(transform.position, amount);
        VFXManager.Instance.CreateHitParticle(transform.position);
    }

    private void Die()
    {
        OnDeath?.Invoke();
        UnSubscribe();
        IsAlive = false;
        _animator.SetTrigger("Die");
        if (this is Hero)
        {
            PartyManager.Instance.Heroes.Remove(this);
        }
        else if (this is Enemy)
        {
            PartyManager.Instance.Enemies.Remove(this);
        }

        StartCoroutine(WaitUntillDeathAnimationEnd());
    }

    private void StartOfTurnReset()
    {
        ClearBlock();
        RegainAP();
        UpdateUI();
    }

    public void ClearBlock()
    {
        if (_loseAllBlock)
        {
            CurrentBlock = 0;
        }
        else
        {
            CurrentBlock -= AmountOfBlockToLose;
        }
        UpdateUI();
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

    public void PlayAnimation(CardType cardType)
    {
        if(_animator != null)
        {
            _animator.SetTrigger("Attack");
        }        
    }
   public IEnumerator WaitUntillDeathAnimationEnd()
    {
        yield return new WaitUntil(() => DoneDying);
        transform.parent.gameObject.SetActive(false);

        if (this is Hero)
        {
            if (PartyManager.Instance.Heroes.Count == 0)
            {
                TurnManager.Instance.LoseGame();
            }
        }
        else if (this is Enemy)
        {
            if (PartyManager.Instance.Enemies.Count == 0)
            {
                TurnManager.Instance.WinGame();
            }
        }


    }

}
