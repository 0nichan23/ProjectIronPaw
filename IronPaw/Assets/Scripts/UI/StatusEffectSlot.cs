using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusEffectSlot : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    Image image;

     public StatusEffect myStatus;



    public void SetUp(StatusEffect effect)
    {
        myStatus = effect;
        text.text = myStatus.TurnCounter.ToString();
        image.sprite = PrefabManager.Instance.GetSprite(myStatus);
    }


    public void UpdateStatusEffectUI()
    {
        text.text = myStatus.TurnCounter.ToString();
        if (myStatus.TurnCounter <= 0)
        {
            Destroy(gameObject);
        }
    }
}
