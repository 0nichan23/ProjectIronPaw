using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatusEffectsInfoScreen : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private GameObject _statusEffectsContainer;
    [SerializeField] private List<StatusEffectToolTip> _children = new List<StatusEffectToolTip>();

    [SerializeField] private GameObject _heroesContainer;
    [SerializeField] private GameObject _enemiesContainer;

    // 
    private int _numberOfStatsBuffer = 4;

    public void InitInfo(Character character)
    {
        TurnOnModel(character);

        _statusEffectsContainer.gameObject.SetActive(false);
        TurnOffAllTooltips();

        if (character.RefSlot.Stats.Count > 0)
        {
            InitStatsToolTips(character);
        }

        if (character.ActiveStatusEffects.Count > 0)
        {
            InitStatusEffectsToolTips(character);
        }
    }

    private void TurnOnModel(Character givenCharacter)
    {
        //RON BANDEL

        List<Character> pointerList = null;
        GameObject pointerContainer = null;

        if (givenCharacter is Hero)
        {
            pointerList = PartyManager.Instance.Heroes;
            pointerContainer = _heroesContainer;
        }
        else if (givenCharacter is Enemy)
        {
            pointerList = PartyManager.Instance.Enemies;
            pointerContainer = _enemiesContainer;
        }

        for (int i = 0; i < PartyManager.Instance.Heroes.Count; i++)
        {
            _heroesContainer.transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < PartyManager.Instance.Enemies.Count; i++)
        {
            _enemiesContainer.transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < pointerList.Count; i++)
        {
            if (pointerList[i] == givenCharacter)
            {
                pointerContainer.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        // ARUR TIYE
    }

    private void TurnOffAllTooltips()
    {
        for (int i = 0; i < _children.Count; i++)
        {
            _children[i].gameObject.SetActive(false);
        }
    }

    private void InitStatsToolTips(Character character)
    {
        // only goes over the first 4 children (stats)
        _statusEffectsContainer.gameObject.SetActive(true);

        foreach (var stat in character.RefSlot.Stats)
        {
            var child = _children[((int)stat.MyStat)];
            child.gameObject.SetActive(true);
            child.InitTurnCounter(stat.MyStatAmount);
        }

        _scrollRect.horizontalNormalizedPosition = 1; //reset scroller position
    }

    private void InitStatusEffectsToolTips(Character character)
    {
        _statusEffectsContainer.gameObject.SetActive(true);

        // Goes over all children but the first four (status effects)
        for (int i = 0; i < character.ActiveStatusEffects.Count; i++)
        {
            int typeCast = ((int)character.ActiveStatusEffects[i].StatusEffectType);
            int childIndex = typeCast + _numberOfStatsBuffer;
            _children[childIndex].gameObject.SetActive(true);
            _children[childIndex].InitTurnCounter(character.ActiveStatusEffects[i].TurnCounter);
        }

        _scrollRect.horizontalNormalizedPosition = 1; //reset scroller position
    }
}
