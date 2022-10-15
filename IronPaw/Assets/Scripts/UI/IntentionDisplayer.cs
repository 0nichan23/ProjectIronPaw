using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class IntentionDisplayer : MonoBehaviour
{
    [SerializeField] private Image _intentionTypeImage;

    [SerializeField] private Image _targetedCharacterImage;

    TextMeshProUGUI DamageText;

    [SerializeField] private Sprite _multipleTargetsSprite;

    private void Start()
    {
        DamageText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void DisplayIntention(List<Character> targets, Card playedCard, Enemy playingEnemy, Damage damage)
    {
        
        if (targets.Count == 0)
        {
            return;
        }
        if (targets.Count > 1)
        {
            _targetedCharacterImage.gameObject.SetActive(true);
            _targetedCharacterImage.sprite = _multipleTargetsSprite;
        }
        else
        {
            if (targets[0] == playingEnemy)
            {
                _targetedCharacterImage.gameObject.SetActive(false);
            }
            else
            {
                _targetedCharacterImage.gameObject.SetActive(true);        
                _targetedCharacterImage.sprite = targets[0].CharacterSprite;
            }
        }


        switch (playedCard.CardType)
        {
            case CardType.Attack:
                if(damage == null)
                {
                    break;
                }
                DamageText.gameObject.SetActive(true);
                float dmg = damage.FinalDamage;

                if(AreAllTargetsAfflictedByStatusEffect(StatusEffectType.Immune, targets))
                {
                    dmg = 0;
                }
                else
                {
                    if (AreAllTargetsAfflictedByStatusEffect(StatusEffectType.Frail, targets))
                    {
                        dmg *= 1.5f;
                    }
                }     
                
                DamageText.text = ((int)dmg).ToString();
                break;
            case CardType.Guard:
                DamageText.gameObject.SetActive(false);
                break;
            case CardType.Utility:
                DamageText.gameObject.SetActive(false);
                break;
            default:
                break;
        }
        _intentionTypeImage.sprite = PrefabManager.Instance.GetIntentionTypeSprite(playedCard);
    }

    private bool AreAllTargetsAfflictedByStatusEffect(StatusEffectType statusEffectType, List<Character> targets)
    {
        foreach (var character in targets)
        {
            if(!character.IsAfflictedBy(statusEffectType))
            {
                return false;
            }
        }

        return true;
    }


}
