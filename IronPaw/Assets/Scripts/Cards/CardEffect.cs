using System.Collections.Generic;
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
        if (playingCharacter is Hero)
        {
            InitializePlayEffect(playingCharacter);
        }

        foreach (var target in Targets)
        {
            PlayCardEffect(playingCharacter, target);
        }
        playingCharacter.Controller.OnPlayCard?.Invoke(card);
        UIManager.Instance.UpdateAllCharacterUIs();
        Targets.Clear();
    }

    protected abstract void PlayCardEffect(Character playingCharacter, Character target);


}
