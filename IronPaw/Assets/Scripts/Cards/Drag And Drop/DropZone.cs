using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();

        if(draggable != null)
        {
            draggable.ParentToReturnTo = transform;
            CardUI cardUI = draggable.gameObject.GetComponent<CardUI>();
            if (cardUI != null)
            {
                Debug.Log("cardUI functional?");
                StartCoroutine(PartyManager.Instance.WaitUntilHeroIsClickedPlayCard(cardUI.CardSO));            
            }
        }
    }
}
