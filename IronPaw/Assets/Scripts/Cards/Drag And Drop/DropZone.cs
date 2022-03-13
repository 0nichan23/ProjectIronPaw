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
            if(draggable.gameObject.GetComponent<CardUI>())
            {
                // Character selection


                // draggable.gameObject.GetComponent<CardUI>().CardSO.PlayCard(hero);
            }
        }
    }
}
