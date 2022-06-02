using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardPressHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private CardUI _cardUI;

    public void OnPointerDown(PointerEventData eventData)
    {
        _cardUI.OnPressStart();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _cardUI.OnPressRelease();
    }
}
