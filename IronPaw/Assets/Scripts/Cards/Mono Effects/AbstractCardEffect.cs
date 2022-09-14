using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCardEffect : MonoBehaviour
{
    public TargetType TargetType;
    public List<Character> Targets = new List<Character>();

    public virtual void InitializePlayEffect(Character playingCharacter) { }

    public void PlayEffect(Character playingCharacter, Card card)
    {

        foreach (var target in Targets)
        {
            PlayCardEffect(playingCharacter, target);
        }

        OneTimeEffect(playingCharacter);

        playingCharacter.Controller.InvokeOnPlayCard(card);
        UIManager.Instance.UpdateAllCharacterUIs();
        Targets.Clear();
    }

    protected abstract void PlayCardEffect(Character playingCharacter, Character target);

    protected virtual void OneTimeEffect(Character playingCharacter)
    {

    }
}
