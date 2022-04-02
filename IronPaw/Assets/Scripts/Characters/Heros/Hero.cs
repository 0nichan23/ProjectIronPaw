using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    private bool _selectable;

    public bool Selectable { get => _selectable; set => _selectable = value; }


    public override void GainBlock(int amount)
    {
        _currentBlock += amount;
    }
    public override void ClearBlock()
    {
        _currentBlock = 0;
    }

    public override void Heal(int amount)
    {
        _currentHp += amount;
        if (_currentHp >= _maxHp)
        {
            _currentHp = _maxHp;
        }
    }

    public override void TakeDmg(int amount)
    {
        _currentHp -= amount;
        Debug.Log("i took " + amount + " dmg");
        DamagePopup.Create(transform.position, amount);
        if (_currentHp <= 0)
        {
            _currentHp = 0;
        }
    }

    public override void Subscribe()
    {
        TurnManager.Instance.OnStartPlayerTurn += InvokeStartTurn;
        TurnManager.Instance.OnEndPlayerTurn += InvokeEndTurn;
    }
    public override void UnSubscribe()
    {
        TurnManager.Instance.OnStartPlayerTurn -= InvokeStartTurn;
        TurnManager.Instance.OnEndPlayerTurn -= InvokeEndTurn;
    }

    public virtual void Passive()
    {

    }

    public virtual void SubscribePassive()
    {

    }

    public virtual void Ultimate()
    {

    }

    public void SelectHero()
    {
        PartyManager.Instance.SelectedCharacter = this;
        //Debug.Log("Selected Hero " + this);
    }

}
