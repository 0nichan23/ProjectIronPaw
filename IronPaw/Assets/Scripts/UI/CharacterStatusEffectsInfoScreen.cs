using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterStatusEffectsInfoScreen : MonoBehaviour
{

    [SerializeField] private GameObject _statusEffectsContainer;
    [SerializeField] private List<StatusEffectToolTip> _children = new List<StatusEffectToolTip>();

    [SerializeField] private GameObject _heroesContainer;
    [SerializeField] private GameObject _enemiesContainer;

    public void InitInfo(Character character)
    {
        InitStatusEffectsToolTips(character);
        TurnOnModel(character);
    }

    private void InitStatusEffectsToolTips(Character character)
    {
        if (character.ActiveStatusEffects.Count > 0)
        {
            _statusEffectsContainer.gameObject.SetActive(true);
            for (int i = 0; i < _statusEffectsContainer.transform.childCount; i++)
            {
                _statusEffectsContainer.transform.GetChild(i).gameObject.SetActive(false);
            }

            for (int i = 0; i < character.ActiveStatusEffects.Count; i++)
            {
                int typeCast = ((int)character.ActiveStatusEffects[i].StatusEffectType);
                _children[typeCast].gameObject.SetActive(true);
                _children[typeCast].InitTurnCounter(character.ActiveStatusEffects[i].TurnCounter);

            }
        }
        else
        {
            _statusEffectsContainer.gameObject.SetActive(false);
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
}
