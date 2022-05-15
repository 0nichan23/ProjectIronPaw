using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSlot : MonoBehaviour
{
    //script to display character effects, hp, level etc.. 
    [SerializeField]
    Transform DisplayZone;

    List<StatusEffectSlot> statuses = new List<StatusEffectSlot>();

    [SerializeField]
    HealthBar Hpbar;

    [SerializeField]
    TextMeshProUGUI BlockText;

    [SerializeField]
    Image ActionPointIcon;

    [SerializeField]
    Image IntentionIcon;


    private void Awake()
    {
        Hpbar = GetComponentInChildren<HealthBar>();
    }


    public void SetupCanvas(Character character)
    {
        if (character is Hero)
        {
            IntentionIcon.gameObject.SetActive(false);
        }
        else if (character is Enemy)
        {
            ActionPointIcon.gameObject.SetActive(false);
        }
    }

    public void AddEffect(StatusEffect status)
    {

        foreach (var item in statuses)
        {
            if (status.StatusEffectType == item.myStatus.StatusEffectType)
            {
                UpdateStatuses();
                return;
            }
        }

        DisplayEffect(status);
    }

    public void DisplayEffect(StatusEffect StatusEffect)
    {
        Debug.Log("Displaying New unique Effec");
        GameObject NewEffect = Instantiate(PrefabManager.Instance.EffectSlot, DisplayZone.position, Quaternion.identity, DisplayZone);
        StatusEffectSlot newSlot = NewEffect.GetComponent<StatusEffectSlot>();
        newSlot.SetUp(StatusEffect);
        statuses.Add(newSlot);
    }

    public void UpdateStatuses()
    {
        foreach (var status in statuses)
        {
            status.UpdateStatusEffectUI();
        }
    }

    public void UpdateHpBar(int maxhp ,int curhp)
    {
        Hpbar.UpdateHealthBar(maxhp, curhp);
    }

    public void UpdateBlock(int block)
    {
        BlockText.text = block.ToString();
    }

    public void UpdateIntention()
    {
        IntentionIcon.gameObject.SetActive(true);
       // PrefabManager.Instance.getspriteforintention();??

    }

    public void UpdateActionPoint()
    {
        ActionPointIcon.gameObject.SetActive(false);
    }


    public void RemoveEffect(StatusEffect effect)
    {
        foreach (var item in statuses)
        {
            if (effect.StatusEffectType == item.myStatus.StatusEffectType)
            {
                statuses.Remove(item);
                Destroy(item.gameObject);
                return;
            }
        }
    }





}
