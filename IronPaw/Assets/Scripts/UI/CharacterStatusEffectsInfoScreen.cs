using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterStatusEffectsInfoScreen : MonoBehaviour
{

    [SerializeField] private GameObject _statusEffectsContainer;
    [SerializeField] private List<StatusEffectToolTip> _children = new List<StatusEffectToolTip>();

    [SerializeField] private List<GameObject> _characterModels;

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
        List<Character> pointerList = null;

        if (givenCharacter is Hero)
        {
            pointerList = PartyManager.Instance.Heroes;
        }
        else if (givenCharacter is Enemy)
        {
            pointerList = PartyManager.Instance.Enemies;
        }

        for (int i = 0; i < pointerList.Count; i++)
        {
            if (pointerList[i] == givenCharacter)
            {
                _characterModels[i].SetActive(true);
            }
            else
            {
                _characterModels[i].SetActive(false);
            }
        }
    }
}
