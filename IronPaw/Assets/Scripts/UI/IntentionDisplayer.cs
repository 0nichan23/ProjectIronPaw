using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntentionDisplayer : MonoBehaviour
{
    [SerializeField]
    Image IntentionTypeImage;
    [SerializeField]
    Image TargetedCharacterImage;
    TextMeshProUGUI DamageText;


    private void Start()
    {
        DamageText = GetComponentInChildren<TextMeshProUGUI>();
    }


    public void DisplayIntention(List<Character> targets, CardScriptableObject playedCard, Enemy enemy)
    {
        if (targets.Count == 0)
        {
            return;
        }
        if (targets.Count > 1)
        {
            //do something with list? aoe sprite 
        }
        else
        {
           
            TargetedCharacterImage.sprite = targets[0].CharacterSprite;

        }

        if (playedCard.CardType == CardType.Attack)
        {
            DamageText.gameObject.SetActive(true);
            float dmg = playedCard.CardEffect.DamageValue;
            if (enemy.IsAfflictedBy(StatusEffectType.Weak))
            {
                dmg *= 0.67f;
            }
            DamageText.text =  ((int) dmg).ToString();
        }
        else
        {
            DamageText.gameObject.SetActive(false);
        }
        IntentionTypeImage.sprite = PrefabManager.Instance.GetIntentionTypeSprite(playedCard);
    }
    //private bool CheckIfTargetsAreAlive(List<Character> targets)
    //{ 
    //}

}
