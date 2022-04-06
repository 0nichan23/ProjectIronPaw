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
            CardUI cardUI = draggable.gameObject.GetComponent<CardUI>();
            if (!cardUI.CardSO.CheckCardValidity())
            {
                return;
            }

            draggable.ParentToReturnTo = transform;
            
            if (cardUI != null)
            {
                /* 
                 * Maybe check for card validity here? makes no sense to check after the corutine started, especially in case where the card
                 * inst valid (example: not enough energy, no valid heroes, etc), in which case we might want to return the card display to 
                 * Hand or something
                 */
                StartCoroutine(PartyManager.Instance.WaitUntilHeroIsClickedPlayCard(cardUI.CardSO));            
            }
        }
    }

    public void Abortion()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
