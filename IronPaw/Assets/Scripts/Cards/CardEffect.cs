using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/* 
  Copy this and change when inheriting:
  [CreateAssetMenu(fileName = "New Card", menuName = "Cards/CardEffect/WhiteCards/Utility/WhiteSingleAllyEffect")]
*/

public abstract class CardEffect : ScriptableObject
{
    public TargetType TargetType;
    public List<Character> Targets = new List<Character>();
    public int DamageValue;
    public Damage CardDamage;

    public void InitializePlayEffect(Character playingCharacter)
    {
        CardDamage = new Damage(DamageValue, playingCharacter, true);
    }

    public void PlayEffect(Character playingCharacter, CardScriptableObject card)
    {
        if(card.CardType == CardType.Attack)
        {
            playingCharacter.PlayAnimation(card.CardType);
        }        
        
        if (playingCharacter is Hero)
        {
            InitializePlayEffect(playingCharacter);
        }
        playingCharacter.Controller.OnPlayCard?.Invoke(card);
        foreach (var target in Targets)
        {
            PlayCardEffect(playingCharacter, target);
            target.UpdateUI();
        }
        Targets.Clear();
    }

    protected abstract void PlayCardEffect(Character playingCharacter, Character target);

    
}
