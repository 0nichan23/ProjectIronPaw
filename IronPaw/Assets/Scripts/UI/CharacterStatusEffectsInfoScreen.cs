using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterStatusEffectsInfoScreen : MonoBehaviour
{

    [SerializeField] private GameObject _statusEffectsContainer;
    [SerializeField] private List<StatusEffectToolTip> _children = new List<StatusEffectToolTip>();

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

    public void InitInfo(Character character)
    {
        InitStatusEffectsToolTips(character);
        //init model
    }
}
