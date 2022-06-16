using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusEffectToolTip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _myTurnCounterText;
    
    public void InitTurnCounter(int turns)
    {
        _myTurnCounterText.text = turns.ToString();
    }

}
