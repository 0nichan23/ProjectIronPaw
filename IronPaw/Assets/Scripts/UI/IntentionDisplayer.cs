using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public void DisplayIntention(List<Character> targets, CardScriptableObject playedCard, Enemy playingEnemy)
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

        if (playedCard.CardType == CardType.Attack)
        {
            DamageText.gameObject.SetActive(true);
            float dmg = playedCard.CardEffect.DamageValue;
            if (playingEnemy.IsAfflictedBy(StatusEffectType.Weak))
            {
                dmg *= 0.67f;
            }
            DamageText.text = ((int)dmg).ToString();
        }
        else
        {
            DamageText.gameObject.SetActive(false);
        }
        _intentionTypeImage.sprite = PrefabManager.Instance.GetIntentionTypeSprite(playedCard);
    }
    //private bool CheckIfTargetsAreAlive(List<Character> targets)
    //{ 
    //}

}
