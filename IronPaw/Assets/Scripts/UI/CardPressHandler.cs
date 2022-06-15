using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardPressHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [SerializeField] private CardUI _cardUI;

    private bool _isBeingDragged;

    private Vector3 _originalPosition;

    [SerializeField] private CanvasGroup _canvasGroup;

    // When Clicked, will select card and allow player to begin playing it
    public void OnPointerClick(PointerEventData eventData)
    {
        _cardUI.OnClick();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _originalPosition = transform.position;
        _cardUI.OnPressStart();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _cardUI.OnPressRelease();    
    }
}
