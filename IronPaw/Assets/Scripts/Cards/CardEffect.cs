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


    public void PlayEffect()
    {
        PlayCardEffect();
        Targets.Clear();
    }

    protected abstract void PlayCardEffect();

    
}
