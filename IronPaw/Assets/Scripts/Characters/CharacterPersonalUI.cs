using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPersonalUI : MonoBehaviour
{
    private Camera _mainCamera;

    //script to display character effects, hp, level etc.. 
    [SerializeField]
    Transform DisplayZone;

    private List<StatusEffectSlot> statuses = new List<StatusEffectSlot>();
    private List<StatusEffectSlot> stats = new List<StatusEffectSlot>();

    [SerializeField]
    HealthBar Hpbar;

    [SerializeField]
    TextMeshProUGUI BlockText;

    [SerializeField]
    TextMeshProUGUI ActionPointsText;


    public IntentionDisplayer IntentionDisplayer;

    public List<StatusEffectSlot> Stats { get => stats; }

    private void Awake()
    {
        Hpbar = GetComponentInChildren<HealthBar>();
        IntentionDisplayer = GetComponentInChildren<IntentionDisplayer>();
    }

    private void Start()
    {
        //_mainCamera = UIManager.Instance.MainCamera;
        //Vector3 lookTarget = new Vector3(_mainCamera.transform.position.x, _mainCamera.transform.position.y, -_mainCamera.transform.position.z);
        //gameObject.transform.LookAt(2 * transform.position - _mainCamera.transform.position);
    }


    public void SetupCanvas(Character character)
    {
        if (character is Enemy)
        {
            ActionPointsText.transform.parent.gameObject.SetActive(false);
        }
    }

    // SEs
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

    // Stats
    public void AddStat(Character character, StatType stat)
    {
        foreach (var item in Stats)
        {
            if (stat == item.MyStat)
            {
                UpdateStats();
                return;
            }
        }

        DisplayStat(character, stat);
    }

    private void DisplayStat(Character character, StatType stat)
    {
        GameObject NewEffect = Instantiate(PrefabManager.Instance.EffectSlot, DisplayZone.position, Quaternion.identity, DisplayZone);
        StatusEffectSlot newSlot = NewEffect.GetComponent<StatusEffectSlot>();
        newSlot.SetUp(character, stat);
        Stats.Add(newSlot);
    }

    public void UpdateStats()
    {
        foreach (var stat in Stats)
        {
            stat.UpdateStatUI();
        }
    }

    public void UpdateHpBar(int maxhp, int curhp)
    {
        Hpbar.UpdateHealthBar(maxhp, curhp);
    }

    public void UpdateBlock(int block)
    {
        BlockText.text = block.ToString();
    }

    public void UpdateActionPoint(int maxap, int curap)
    {
        ActionPointsText.text = curap.ToString();
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
