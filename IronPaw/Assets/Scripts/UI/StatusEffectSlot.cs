using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusEffectSlot : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _counter;

    [SerializeField]
    Image image;

    public StatusEffect myStatus;

    private Character _myCaracter;

    public StatType MyStat;

    private int _myStatAmount;
    public void SetUp(StatusEffect effect)
    {
        myStatus = effect;
        _counter.text = myStatus.TurnCounter.ToString();
        Sprite sprite = PrefabManager.Instance.GetSprite(myStatus);

        if(sprite != null)
        {
            image.sprite = sprite;
        }  
    }

    public void SetUp(Character character, StatType stat)
    {
        _myCaracter = character;
         MyStat = stat;
        _myStatAmount = DetermineAmountOfStat(character, stat);
        _counter.text = _myStatAmount.ToString();

        Sprite sprite = PrefabManager.Instance.GetSprite(MyStat);

        if (sprite != null)
        {
            image.sprite = sprite;
        }
    }

    private int DetermineAmountOfStat(Character character, StatType stat)
    {
        switch(stat)
        {
            case StatType.STRENGTH:
                return character.Stats.Strength;

            case StatType.DEXTERITY:
                return character.Stats.Dexterity;

            case StatType.INTELLIGENCE:
                return character.Stats.Intelligence;

            case StatType.FAITH:
                return character.Stats.Faith;

            default:
                return 0;
        }
    }

    public void UpdateStatusEffectUI()
    {
        _counter.text = myStatus.TurnCounter.ToString();
        if (myStatus.TurnCounter <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateStatUI()
    {
        _myStatAmount = DetermineAmountOfStat(_myCaracter, MyStat);
        _counter.text = _myStatAmount.ToString();
        if (_myStatAmount == 0)
        {
            Destroy(gameObject);
        }
    }
}
